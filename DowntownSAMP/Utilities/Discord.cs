using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace DowntownSAMP.Utilities
{
    public class Discord
    {
        public static byte[] Post(string url, NameValueCollection pairs)
        {
            using (WebClient webClient = new WebClient())
                return webClient.UploadValues(url, pairs);
        }

        public static void sendWebHook(int type, string message)
        {
            string url = "";
            string username = "";
            switch (type)
            {
                case 1:
                    url = "https://discordapp.com/api/webhooks/645882762389225472/kMkSQaFgNSCv_kZf2bmLpjsc7YMz8-iMfJ1Kj2XLkjtJ0I339oIgwFEy2qmBD8ec3GtZ";
                    username = "Downtown Logs";
                    break;
            }

            Discord.Post(url, new NameValueCollection()
            {
                {
                    "username",
                    username
                },
                {
                    "content",
                    message
                }
            });
        }
    }
}
