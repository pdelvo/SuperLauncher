using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;
using MarkdownSharp;
using System.Web.Script.Serialization;

namespace web.Models
{
    public class ItemViewModel
    {
        public ItemViewModel(Item item)
        {
            var markdown = new Markdown();
            Name = item.Name;
            DescriptionHtml = markdown.Transform(item.Description);
            DescriptionMarkdown = item.Description;
            ImageUrl = item.ImageUrl;
            Type = item.Type;
            Address = item.Address;
            DetailedUrl = "/item/" + item.Id;
            Id = item.Id;
            Item = item;
            Version = item.Version;
            FriendlyVersion = item.FriendlyVersion;
            Dependencies = new List<DependencyViewModel>();
            foreach (var dependency in Item.Dependencies)
                Dependencies.Add(new DependencyViewModel(dependency));
            Blobs = new List<BlobViewModel>();
            foreach (var blob in Item.Blobs)
                Blobs.Add(new BlobViewModel(blob));
            User = item.User;
        }

        [ScriptIgnore]
        public Item Item { get; set; }
        public string Name { get; set; }
        public string DescriptionHtml { get; set; }
        public string DescriptionMarkdown { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string DetailedUrl { get; set; }
        public long Id { get; set; }
        public long Version { get; set; }
        public string User { get; set; }
        public string FriendlyVersion { get; set; }
        public List<DependencyViewModel> Dependencies { get; set; }
        public List<BlobViewModel> Blobs { get; set; }
    }
}