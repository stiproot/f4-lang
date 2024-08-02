using Microsoft.Extensions.DependencyInjection;

internal static class AgntManagerSample
{
    public static async Task RunAsync()
    {
        const bool loadDocs = true;
        if(loadDocs) await InitDocLoader.LoadAsync();

        var provider = ServiceCollectionFactory.Create()
            .AddSlowCoreServices()
            .AddSlowConfiguration()
            .AddMappingRules()
            .BuildServiceProvider();

        var agntManager = provider.GetService<IAgntManager>()!;
        var qry = new AgntManagerQry 
        { 
            RawTxtQry = @"""
            Write code to implement the following blueprint:
            ``.
            Write the output to the following file ``.
            """
        };

        var cancellationToken = new CancellationToken();
        var result = await agntManager.ManageAsync(qry, cancellationToken);
        Console.WriteLine(result.RawTxtRes);

        while (true)
        {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            qry = new AgntManagerQry { RawTxtQry = input };
            result = await agntManager.ManageAsync(qry, cancellationToken);

            Console.WriteLine($"Agnt: {result.RawTxtRes}");
        }
    }
}