using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownSharp;
using web.Models;
using web.Service.Model;

namespace web.Controllers
{
    public class LauncherController : Controller
    {
        public ActionResult Item(int id)
        {
            ItemViewModel viewModel;
            using (var database = new DatabaseEntities())
            {
                var items = from i in database.Items
                           where i.Id == id
                           select i;
                if (!items.Any())
                {
                    Response.StatusCode = 404;
                    return null;
                }
                viewModel = new ItemViewModel(items.First());
            }
            return View(viewModel);
        }

        public JsonResult Details(int id)
        {
            var downloads = new DownloadCollection();
            using (var database = new DatabaseEntities())
            {
                var items = from i in database.Items
                            where i.Id == id
                            select i;
                if (!items.Any())
                {
                    Response.StatusCode = 404;
                    return null;
                }
                var root = items.First();
                downloads.PrimaryItem = new ItemViewModel(root);
                AddDependencies(downloads, root);
            }
            return Json(downloads, JsonRequestBehavior.AllowGet);
        }

        private void AddDependencies(DownloadCollection collection, Item item)
        {
            collection.Items.Add(new ItemViewModel(item));
            foreach (var blob in item.Blobs)
            {
                collection.Downloads.Add(new Download
                {
                    DestinationPath = blob.DestinationPath,
                    DownloadUrl = blob.DownloadUrl
                });
            }
            foreach (var dependency in item.Dependencies)
                AddDependencies(collection, dependency.Item);
        }

        public ActionResult Category(string id)
        {
            var categories = id.Split('/');
            id = categories.Last();
            var viewModel = new CategoryViewModel();
            using (var database = new DatabaseEntities())
            {
                var category = (from c in database.Categories
                                where c.Name.ToLower() == id.ToLower()
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
                                where i.Id == category.FeaturedItem
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
