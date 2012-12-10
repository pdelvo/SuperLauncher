using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web.Service.Model;

namespace web.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel(Category category) : this()
        {
            Name = category.Name;
            if (category.Featured != null)
                FeaturedItem = new ItemViewModel(category.Featured);
            Items = new List<ItemViewModel>(category.Items.Select(i => new ItemViewModel(i)));
            Subcategories = new List<CategoryViewModel>(category.Children.Select(c => new CategoryViewModel(c)));
            Id = category.Id;
        }

        public CategoryViewModel()
        {
            Subcategories = new List<CategoryViewModel>();
            Items = new List<ItemViewModel>();
        }

        public string Name { get; set; }
        public ItemViewModel FeaturedItem { get; set; }
        public List<CategoryViewModel> Subcategories { get; set; }
        public Category ParentCategory { get; set; }
        public string RootPath { get; set; }
        public List<ItemViewModel> Items { get; set; }
        public int Id { get; set; }
    }
}