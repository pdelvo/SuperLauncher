using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class FeaturedItemViewModel
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}