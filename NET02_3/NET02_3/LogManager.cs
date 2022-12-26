using EventLogListener;
using Interface;
using System.Configuration;
using System.Reflection;
using WordListener;
using TextListener;
using WordListener;

namespace NET02_3
{
    public class LogManager
    {
        public ILogger GetLogger()
        {//create logger of specific type
            Assembly asm = Assembly.LoadFrom(ConfigurationManager.AppSettings["AssemblyName"]);
            Type? t = asm.GetType(ConfigurationManager.AppSettings["LoggerType"]);
            if (t is not null)
            {
                return (ILogger)Activator.CreateInstance(t);
            }
            return null;
        }
        /*
        public void Ptint()
        {
            var loggers = new List<string>();// what type
            //loggers.Add();
            //loggers.Add();
            //loggers.Add();

            foreach (var logger in loggers)
            {
                Console.WriteLine(logger);
            }
        }
        */

    }
}
