using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace web
{
    public class MCUpdate
    {
        static MCUpdate()
        {
            Updates = new List<Update>();
            LastFetch = DateTime.MinValue;
        }

        public static List<Update> Updates { get; set; }
        public static DateTime LastFetch { get; set; }

        public static void Fetch()
        {
            LastFetch = DateTime.Now;
            var client = new WebClient();
            var rss = client.DownloadString("http://mcupdate.tumblr.com/rss");
            var document = XDocument.Parse(rss);
            var dc = XNamespace.Get("http://purl.org/dc/elements/1.1/");
            Updates = new List<Update>();
            foreach (var item in document.Root.Element("channel").Elements("item"))
            {
                var update = new Update();
                update.Name = item.Element("title").Value;
                update.Link = item.Element("link").Value;
                update.Html = HttpUtility.HtmlDecode(item.Element("description").Value);
                Updates.Add(update);
            }
        }

        public class Update
        {
            public string Name { get; set; }
            public string Html { get; set; }
            public string Link { get; set; }
        }
    }
}