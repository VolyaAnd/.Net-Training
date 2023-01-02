using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace NET02_4
{
    public class Website
    {
        // create a static logger field
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HttpStatusCode CheckWebsiteAccessibility(Setting setting)
        {
            var request = (HttpWebRequest)WebRequest.Create(setting.uri);
            request.Timeout = int.Parse(setting.timeout) * 1000;
            request.Method = "HEAD";
            var response = (HttpWebResponse)request.GetResponse();
            logger.Info($"ping site {setting.uri}");
            return response.StatusCode;
        }

    }
}
