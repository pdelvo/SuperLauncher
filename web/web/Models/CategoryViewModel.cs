using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;

namespace web.Models
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public ItemViewModel FeaturedItem { get; set; }
    }
}