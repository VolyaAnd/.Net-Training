using System.Net;
using System.Net.Mail;
using System.Configuration;
//using Timer = System.Threading.Timer;

namespace NET02_4
{
    class Program
    {      
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static Website ws;
        private static List<Timer> timerList = new List<Timer>();

        static async Task SendEmail(Setting setting)
        {
            //const string To = "ola.androva@gmail.com";
            const string From = "ola.androva@gmail.com";

            const string GoogleAppPassword = "zbdzghqelathyeyu";

            const string Subject = "Attention";
            string Body = $"<h1>Website {setting.uri} does not respond. Please fix it.</h1>"; 
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(From, GoogleAppPassword),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(From),
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(setting.email);

            smtpClient.Send(mailMessage);
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Config file was changed!!!!!");
            Console.WriteLine("Stop all timers");

            // stop all
            List<Setting> siteList = ConfigurationManager.GetSection("websiteSettings") as List<Setting>;
            foreach (var timer in timerList)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }

            // start all
            RunRun();
        }

        private static void RunRun()
        {
            Console.WriteLine("Start all timers");

            ConfigurationManager.RefreshSection("websiteSettings");
            List<Setting> siteList = ConfigurationManager.GetSection("websiteSettings") as List<Setting>;
            foreach (Setting setting in siteList)
            {
                int timeInterval = int.Parse(setting.interval);

                Timer timer = new Timer(callback, setting, TimeSpan.FromSeconds(timeInterval), TimeSpan.FromSeconds(timeInterval));
                timerList.Add(timer);

            }
        }

        static async Task Main(string[] args)
        {
            using (var mutex = new Mutex(false, "MyUniqueMutex"))
            {
                bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
                if (isAnotherInstanceOpen)
                {
                    Console.WriteLine("Only one instance of this app is allowed.");
                    return;
                }

                ws = new Website();
                
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Environment.CurrentDirectory;
                watcher.Filter = "NET02_4.dll.config";
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.EnableRaisingEvents = true;

                RunRun();

                Console.ReadKey();
                mutex.ReleaseMutex();
            }

        }

        static async void callback(object obj)
        {
            Setting setting = obj as Setting;
            Console.WriteLine("Called back with state = " + setting.uri);
            try
            {
                ws.CheckWebsiteAccessibility(setting);
            }
            catch (WebException ex)
            {
                logger.Error($"Website {setting.uri}is not available");
                await SendEmail(setting);
            }
        }
    }
}