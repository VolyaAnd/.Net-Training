using System;
using System.Reflection.PortableExecutable;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NET02_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var configPath = @"C:\Users\VolhaAndrava\source\repos\NET02_2\Config";
            var serializer = new XmlSerializer(typeof(Config));
            StreamReader file = new StreamReader(Path.Combine(configPath, "XMLFile1.xml"));
            Config config = (Config)serializer.Deserialize(file); 
            file.Close();
            foreach ( var login in config.LoginArray)
            {
                login.PrintLog();
            }
            config.LoginValidate();
            config.FixConfig();
            config.Save(configPath);
            Console.WriteLine(JsonSerializer.Serialize(config));


        }
    }

}
