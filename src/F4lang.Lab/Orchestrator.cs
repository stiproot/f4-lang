using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using PromiseTree;

public interface IManager
{
    Task<bool> CheckConditionAsync();
    Task ProcessAsync();
    Task HandleErrorAsync();
}

public class DbManager : IManager
{
    public Task<bool> CheckConditionAsync() => Task.FromResult(true);
    public Task ProcessAsync() => Task.CompletedTask; // implement db processing
    public Task HandleErrorAsync() => Task.CompletedTask; // implement error handling
}

public class HttpManager : IManager
{
    public Task<bool> CheckConditionAsync() => Task.FromResult(true);
    public Task ProcessAsync() => Task.CompletedTask; // implement http request
    public Task HandleErrorAsync() => Task.CompletedTask; // implement error handling
}

public class FileManager : IManager
{
    public Task<bool> CheckConditionAsync()
    {
        bool fileExists = File.Exists('/path/to/file');
        return Task.FromResult(fileExists);
    }

    public Task ProcessAsync() => Task.CompletedTask; // implement file read
    public Task HandleErrorAsync() => Task.CompletedTask; // implement error handling
}

public class Orchestrator
{
    private readonly IManager _dbManager;
    private readonly IManager _httpManager;
    private readonly IManager _fileManager;
    private readonly StateManager _stateManager;

    public Orchestrator(IManager dbManager, IManager httpManager, IManager fileManager, StateManager stateManager)
    {
        _dbManager = dbManager;
        _httpManager = httpManager;
        _fileManager = fileManager;
        _stateManager = stateManager;
    }

    public async Task ExecuteWorkflowAsync()
    {
        var cancellationToken = new CancellationToken();
        
        var metaNode = _stateManager
            .RootIf(_fileManager.CheckConditionAsync())
            .Then(httpManager)
            .Else(dbManager);
        
        var node = await metaNode.Build();
        
        var msg = await node.Result(async _ => true, cancellationToken);
        
        if (!msg) throw new Exception('Error occurred while executing the workflow');
    }
}