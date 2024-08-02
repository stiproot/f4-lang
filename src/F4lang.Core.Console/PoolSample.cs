using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

internal static class PoolSample
{
    public static async Task RunAsync()
    {
        const bool loadDocs = false;
        if(loadDocs) await InitDocLoader.LoadAsync();

        var provider = ServiceCollectionFactory.Create()
            .AddSlowCoreServices()
            .AddSlowConfiguration()
            .AddMappingRules()
            //.AddCachingServices()
            .BuildServiceProvider();

        var agntPools = provider.GetService<IOptions<AgntPoolOptions>>()!.Value.AgntPools;
        var agntMetadataLoader = provider.GetService<IAgntMetadataLoader>();
        AgntPoolMetadataModel agntPoolMetadata = agntPools.First(p => p.AgntPoolId is "promise-tree-pool");
        var agntMetadataModelsTasks = agntPoolMetadata.Agnts.Select(a => agntMetadataLoader!.LoadJsnAsync(a.Metafile));
        var agntMetadataModels = await Task.WhenAll(agntMetadataModelsTasks);

        var agntPool = provider.GetService<IAgntPool>()!.Init(agntMetadataModels);
        var cancellationToken = new CancellationToken();
        var agntQry = new AgntPoolQry 
        { 
            RawTxtQry = """
            I would like you to write some C# code.
            I would like an `IManager` interface defined, and I would like 3 implementations of this interface.
            One should manage DB connections, one should manager HTTP restful service connections, and one should manage file system connections.

            I would like an `Orchestrator` class that uses these three managers to perform a workflow.

            The workflow should be as follows:
            1. Check a file system location for a file.
            2. If the file is found, then post the contents to a restful API endpoint.
            3. Else store an error message in a database table.

            Use the `PromiseTree` library in the `Orchestrator` to manage the workflow.

            Write your output file to this location `~/f4lang/src/F4lang.Lab/`.
            """,
            LeadAgntId = agntPoolMetadata.LeaderAgntId
        };

        await agntPool.ManageAsync(agntQry, cancellationToken);
        Console.WriteLine(agntPool.Result);

    }
}
