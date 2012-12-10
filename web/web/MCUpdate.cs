using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using HtmlAgilityPack;

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
            var document = new HtmlDocument();
            document.LoadHtml(client.DownloadString("http://mcupdate.tumblr.com"));
            var body = document.DocumentNode.Descendants("body").First();
            var posts = body.Descendants("div").Where(n => n.Attributes["class"] != null &&
                n.Attributes["class"].Value == "post text");
            foreach (var post in posts)
            {
                var update = new Update();
                update.Name = post.Descendants("h3").First().Descendants("a").First().InnerText;
                update.Link = post.Descendants("h3").First().Descendants("a").First().Attributes["href"].Value;
                update.Html = "";
                foreach (var p in post.Descendants("p"))
                    update.Html += "<p>" + HttpUtility.HtmlDecode(p.InnerHtml) + "</p>" + Environment.NewLine;
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