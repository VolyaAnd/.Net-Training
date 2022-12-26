using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Interface;
using System.Configuration;
using System.Reflection;

namespace WordListener
{
    public class WordLogger : ILogger
    {
        //create if not exist?   
        public string filePath = @"C:\Users\VolhaAndrava\source\repos\NET02_3\WordFile1.docx";
        public void Log(string message)
        {
            using (var document = WordprocessingDocument.Create(
               filePath, WordprocessingDocumentType.Document))
            {
                document.AddMainDocumentPart();
                document.MainDocumentPart.Document = new Document(
                    new Body(new Paragraph(new Run(new Text(message)))));
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