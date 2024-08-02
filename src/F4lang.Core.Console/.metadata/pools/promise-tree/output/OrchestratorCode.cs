using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Orchestration
{
    public interface IManager
    {
        Task Process();
    }

    public class DBManager : IManager
    {
        public async Task Process()
        {
            // Code to execute DB operation goes here.
        }
    }

    public class HTTPManager : IManager
    {
        private HttpClient _client;

        public HTTPManager()
        {
            _client = new HttpClient();
        }

        public async Task Process()
        {
            // Code to execute HTTP requests goes here.
        }
    }

    public class FileManager : IManager
    {
        public async Task Process()
        {
            // Code to execute File operations goes here.
        }
    }

    public class Orchestrator
    {
        private IManager _dbManager;
        private IManager _httpManager;
        private IManager _fileManager;

        public Orchestrator(DBManager dbManager, HTTPManager httpManager, FileManager fileManager)
        {
            _dbManager = dbManager;
            _httpManager = httpManager;
            _fileManager = fileManager;
        }

        public async Task PerformWorkflow()
        {
            try
            {
                await _fileManager.Process();
                await _httpManager.Process();
            }
            catch (Exception)
            {
                await _dbManager.Process();
            }
        }
    }
}
