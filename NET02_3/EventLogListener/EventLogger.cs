using Interface;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace EventLogListener
{
    public class EventLogger: ILogger
    {
        public void Log(string message)
        {
            using (EventLog neweventLog = new EventLog("Application"))
            {
                neweventLog.Source = "Application";
                neweventLog.WriteEntry(message, EventLogEntryType.Information, 102, 1);
            }
        }

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
    }
}