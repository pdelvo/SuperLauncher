using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;
using MarkdownSharp;
using System.Web.Script.Serialization;
using System.ComponentModel.DataAnnotations;
using Foolproof;

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
            Approved = item.Approved;
        }

        [ScriptIgnore]
        public Item Item { get; set; }
        [Required]
        public string Name { get; set; }
        public string DescriptionHtml { get; set; }
        [Required]
        [StringLength(1000)]
        public string DescriptionMarkdown { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        [RequiredIf("Type", "Server")]
        public string Address { get; set; }
        public string DetailedUrl { get; set; }
        public long Id { get; set; }
        public long Version { get; set; }
        public string User { get; set; }
        [Required]
        public string FriendlyVersion { get; set; }
        public bool Approved { get; set; }
        public bool PendingUpdate { get; set; }
        [ScriptIgnore]
        public List<DependencyViewModel> Dependencies { get; set; }
        [ScriptIgnore]
        public List<BlobViewModel> Blobs { get; set; }
    }
}