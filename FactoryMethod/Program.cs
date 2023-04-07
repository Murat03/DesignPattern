using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();

            Console.ReadLine();
        }
    }
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory which ILogger will return
            return new MiLogger();
        }
    }
    public class LoggerFactory2:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory which ILogger will return
            return new LogForNetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class MiLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with MiLogger");
        }
    }
    public class LogForNetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with LogForNetLogger");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
