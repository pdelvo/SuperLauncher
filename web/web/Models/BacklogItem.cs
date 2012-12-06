using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class BacklogItem
    {
        public string Type { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string FriendlyVersion { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}