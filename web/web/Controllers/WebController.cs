using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownSharp;
using web.Models;
using web.Service.Model;
using System.Data.Entity;

namespace web.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Category(string name)
        {
            var categories = name.Split('/');
            name = categories.Last();
            var viewModel = new CategoryViewModel();
            using (var database = new DataEntities())
            {
                var category = (from c in database.Categories
                                where c.Name.ToLower() == name.ToLower()
                                select c).FirstOrDefault();
                if (category == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                var subcategories = from c in database.Categories
                                    where c.Parent == category.Id
                                    select c;
                var parent = (from c in database.Categories
                             where c.Id == category.Parent
                             select c).FirstOrDefault();
                viewModel.Name = category.Name;
                var featured = (from i in database.Items
                                where i.Id == category.Featured
                                select i).FirstOrDefault();
                if (featured != null)
                    viewModel.FeaturedItem = new ItemViewModel(featured);
                viewModel.Items = new List<Item>(category.Items.Skip(0).Take(10)); // TODO: Pagination
                viewModel.Subcategories = new List<Category>(subcategories.ToArray());
                viewModel.ParentCategory = parent;
            }
            return View(viewModel);
        }
    }
}
