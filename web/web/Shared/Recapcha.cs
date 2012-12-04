using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Net;
using System.Text;
using System.IO;

namespace web.Shared
{
    public static class Recapcha
    {
        public static bool ValidateCapcha(HttpRequestBase request, string challenge, string value, out string error)
        {
            error = null;
            string privateKey = WebConfigurationManager.AppSettings["RecapchaPrivateKey"];
            bool enabled = bool.Parse(WebConfigurationManager.AppSettings["RecapchaEnabled"]);
            if (!enabled)
                return true;
            var apiRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com/recaptcha/api/verify");
            apiRequest.Method = "POST";
            apiRequest.ContentType = "application/x-www-form-urlencoded";
            string data = string.Format("privatekey={0}&remoteip={1}&challenge={2}&response={3}",
                Uri.EscapeDataString(privateKey), Uri.EscapeDataString(request.UserHostAddress), 
                Uri.EscapeDataString(challenge), Uri.EscapeDataString(value));
            apiRequest.ContentLength = data.Length;
            var stream = apiRequest.GetRequestStream();
            byte[] rawData = Encoding.UTF8.GetBytes(data);
            stream.Write(rawData, 0, rawData.Length);
            stream.Close();
            var response = apiRequest.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd().Split('\n');
            response.Close();
            if (result[0] == "false")
                error = result[1];
            return result[0] == "true";
        }
    }
}
