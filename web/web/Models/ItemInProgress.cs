using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;

namespace web.Models
{
    public class ItemInProgress
    {
        public ItemInProgress()
        {
            Blobs = new List<BlobViewModel>();
            Dependencies = new List<DependencyViewModel>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<BlobViewModel> Blobs { get; set; }
        public List<DependencyViewModel> Dependencies { get; set; }
        public ItemType ItemType { get; set; }
        public string ImageUrl { get; set; }
    }

    public enum ItemType
    {
        Map,
        Server,
        TexturePack,
        Mod,
        Skin
    }
}