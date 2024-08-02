using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;

public interface IManager
{
    Task<string> ManageAsync();
}

public class DBManager : IManager
{
    public async Task<string> ManageAsync()
    {
        // Implement DB connection and operations here
        return "DB Operation performed";
    }
}

public class HttpManager : IManager
{
    public async Task<string> ManageAsync()
    {
        // Implement HTTP restful service connection and operations here
        return "Http Operation performed";
    }
}

public class FileManager : IManager
{
    public async Task<string> ManageAsync()
    {
        // Implement file system connection and operations here
        return "File operation performed";
    }
}