using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class NestedCategoryDescriptor
    {
        public string Name { get; set; }
        public List<NestedCategoryDescriptor> Subcategories { get; set; }
        public int Id { get; set; }
    }
}