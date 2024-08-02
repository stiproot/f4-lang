using System;

namespace F4lang.Lab
{
    public interface IManager
    {
        void Execute();
    }

    public class DBManager : IManager
    {
        public void Execute()
        {
            throw new NotImplementedException("Functionality for DBManager Execute method not implemented.");
        }
    }

    public class RestfulServiceManager : IManager
    {
        public void Execute()
        {
            throw new NotImplementedException("Functionality for RestfulServiceManager Execute method not implemented.");
        }
    }

    public class FileSystemManager : IManager
    {
        public void Execute()
        {
            throw new NotImplementedException("Functionality for FileSystemManager Execute method not implemented.");
        }
    }
}