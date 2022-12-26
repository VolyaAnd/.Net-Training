using NET02_3;

namespace NET02_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var mgr = new LogManager();
            var logger = mgr.GetLogger();
            logger.LogInfo("something happened again1");
            var myObj = new MyClass()
            {
                Prop1 = "Property1",
                Prop2 = "Property2",
                Prop3 = "Property3",
            };
            logger.Track(myObj); //logging
            logger.Track(mgr); //not logging
        }
    }
}