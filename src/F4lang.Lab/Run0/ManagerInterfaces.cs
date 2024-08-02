public interface IManager
{
    Task ExecuteAsync();
}

public class DBManager : IManager
{
    public Task ExecuteAsync()
    {
        // Implement DB connection management logic here
        throw new NotImplementedException();
    }
}

public class RestServiceManager : IManager
{
    public Task ExecuteAsync()
    {
        // Implement restful service connection management logic here
        throw new NotImplementedException();
    }
}

public class FileManager : IManager
{
    public Task ExecuteAsync()
    {
        // Implement file system connection management logic here
        throw new NotImplementedException();
    }
}