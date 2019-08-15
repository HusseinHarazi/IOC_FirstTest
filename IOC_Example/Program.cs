using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IOC_Example
{
    class Program
    {
               static void Main(string[] args)
        {
            ////code below *WITHOUT* using IOC Principle
            //DBLog obj = new DBLog();
            //obj.logMe();
            //Console.ReadLine();
             //#####################################################################          

            //code below USING IOC Principle (Unity Container) :)
            var container = new UnityContainer();
            container.RegisterType<ILogger, FileLog>();

            var logProcess = container.Resolve<LogProcess>();
            logProcess.logMsg();
            Console.ReadLine();

            //var logProcess1 = new LogProcess(new DBLog());
            //logProcess1.logMsg();
            //Console.ReadLine();
            //var logProcess2 = new LogProcess(new FileLog());
            //logProcess2.logMsg();
            //Console.ReadLine();
        }
    }
   public interface ILogger
    {
        void logMe();
    }
    public class DBLog:ILogger
    {
        public void logMe()
        {
            Console.WriteLine("DB Logging on");
            //here log  to DB Code 
        }
    }
    public class FileLog : ILogger
    {
        public void logMe()
        {
            Console.WriteLine("File Logging on");
            //here log  to File Code 
        }
    }

    public class LogProcess
    {
        private ILogger _log = null;

        public LogProcess(ILogger log)
        {
            _log = log;
        }
        
        public void logMsg()
        {
            Console.WriteLine("{0} ", _log.GetType().Name);
            _log.logMe();
        }
    }

}
