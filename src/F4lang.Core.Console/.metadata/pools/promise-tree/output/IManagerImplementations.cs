using System;
using System.Threading;
using System.Threading.Tasks;
using PromiseTree;

namespace F4lang.Console
{
    public interface IManager
    {
        Task ExecuteAsync(object input, CancellationToken cancellationToken);
    }

    public class DbManager : IManager
    {
        public async Task ExecuteAsync(object input, CancellationToken cancellationToken)
        {
            // Implementation for managing DB connections goes here
        }
    }

    public class RestfulServiceManager : IManager
    {
        public async Task ExecuteAsync(object input, CancellationToken cancellationToken)
        {
            // Implementation for managing HTTP restful service connections goes here
        }
    }

    public class FileSystemManager : IManager
    {
        public async Task ExecuteAsync(object input, CancellationToken cancellationToken)
        {
            // Implementation for managing file system connections goes here
        }
    }

    public class Orchestrator
    {
        private IStateManager _stateManager;
        private DbManager _dbManager;
        private RestfulServiceManager _restfulServiceManager;
        private FileSystemManager _fileSystemManager;

        public Orchestrator(IStateManager stateManager, DbManager dbManager, RestfulServiceManager restfulServiceManager, FileSystemManager fileSystemManager)
        {
            _stateManager = stateManager;
            _dbManager = dbManager;
            _restfulServiceManager = restfulServiceManager;
            _fileSystemManager = fileSystemManager;
        }

        public async Task ExecuteWorkflow(CancellationToken cancellationToken)
        {
            var mn = _stateManager
                .RootIf(_fileSystemManager.ExecuteAsync)
                .Then(_restfulServiceManager.ExecuteAsync)
                .Else(_dbManager.ExecuteAsync);

            var n = mn.Build();

            await n.Resolve(cancellationToken);
        }
    }
}