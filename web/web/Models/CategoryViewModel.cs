using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Service.Model;

namespace web.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Subcategories = new List<Category>();
            Items = new List<Item>();
        }

        public string Name { get; set; }
        public ItemViewModel FeaturedItem { get; set; }
        public List<Category> Subcategories { get; set; }
        public Category ParentCategory { get; set; }
        public string RootPath { get; set; }
        public List<Item> Items { get; set; }
    }
}