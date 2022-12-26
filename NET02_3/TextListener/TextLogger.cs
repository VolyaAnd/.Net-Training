using Interface;
using System.Configuration;
using System.Reflection;

namespace TextListener
{
    public class TextLogger : ILogger
    {
        public string filePath = @"C:\Users\VolhaAndrava\source\repos\NET02_3\TextFile1.txt";
        public void Log(string message)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write)) //to not erase previous info
            using (StreamWriter streamWriter = new StreamWriter(fs))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
        public void Track(object obj)
        {
            Type type = obj.GetType();
            TypeInfo typeInfo = type.GetTypeInfo();
            var attrs = typeInfo.GetCustomAttributes();
            foreach (var attr in attrs)
            {
                if (attr.GetType().Name == "TrackingEntityAttribute")
                {
                    Log("Track: Class = " + typeInfo.AssemblyQualifiedName);
                    foreach (var prop in type.GetProperties())
                    {
                        var propAttrs = prop.GetCustomAttributes();
                        foreach (var propAttr in propAttrs)
                        {
                            if (propAttr.GetType().Name == "TrackingPropertyAttribute")
                            {
                                Log($"Track: Property {prop.Name}={prop.GetValue(obj, null)}");
                            }
                        }
                    }
                }
            }
        }
        //log levels
        public void LogError(string message)
        {
            Log("ERROR: " + message);
        }

        public void LogInfo(string message)
        {
            string LoggerLevel = ConfigurationManager.AppSettings["LoggerType"];
            if (LoggerLevel == "Error" || LoggerLevel == "Warning")
                return;
            Log("INFO: " + message);
        }

        public void LogWarning(string message)
        {
            string LoggerLevel = ConfigurationManager.AppSettings["LoggerType"];
            if (LoggerLevel == "Error")
                return;
            Log("WARNING: " + message);
        }
    }
}