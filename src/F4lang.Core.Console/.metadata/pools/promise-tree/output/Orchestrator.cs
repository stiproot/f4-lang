using PromiseTree;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace F4lang.Console
{
    public interface IManager<T>
    {
        Task<T> ExecuteAsync(string arg);
        bool CheckExistence(string path);
    }

    public class DBManager : IManager<int>
    {
        // Implementation details...
    }

    public class RestfulServiceManager : IManager<string>
    {
        // Implementation details...
    }

    public class FilesystemManager : IManager<FileInfo>
    {
        // Implementation details...
    }

    public class Orchestrator
    {
        private readonly IStateManager stateManager;

        public Orchestrator()
        {
            stateManager = new StateManager();
        }

        public async Task<string> RunWorkflow(CancellationToken cancellationToken)
        {
            var workflow = this.stateManager
                    .RootIf<IManager<FileInfo>>(configure => configure.MatchArg("/path/to/file"))
                    .Then<IManager<string>>(configure => configure.MatchArg("/api/endpoint"))
                    .Else<IManager<int>>(configure => configure.MatchArg("Error message"));

            var node = workflow.Build();

            var msgs = await node.Resolve(cancellationToken);

            return "Workflow completed successfully";
        }
    }
}