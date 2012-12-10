using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using HtmlAgilityPack;
using MarkdownSharp;
using web.Models;
using web.Service.Model;

namespace web.Controllers
{
    public class LauncherController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new LauncherIndexViewModel();
            if ((DateTime.Now - MCUpdate.LastFetch).Minutes > 10)
                MCUpdate.Fetch();
            viewModel.MinecraftUpdates = MCUpdate.Updates;
            return View(viewModel);
        }

        public ActionResult Item(int id)
        {
            ItemViewModel viewModel;
            using (var database = new DatabaseEntities())
            {
                var item = database.ItemById(id);
                if (item == null)
                    return HttpNotFound();
                viewModel = new ItemViewModel(item);
            }
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var downloads = new DownloadCollection();
            using (var database = new DatabaseEntities())
            {
                var item = database.ItemById(id);
                if (item == null)
                    return HttpNotFound();
                downloads.PrimaryItem = new ItemViewModel(item);
                AddDependencies(downloads, item);
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
                AddDependencies(collection, dependency.Provider);
        }

        public ActionResult Category(string id)
        {
            var categories = id.Split('/');
            id = categories.Last();
            var viewModel = new CategoryViewModel();
            using (var database = new DatabaseEntities())
            {
                var category = database.CategoryByName(id);
                if (category == null)
                    return HttpNotFound();
                viewModel.Name = category.Name;
                if (category.Featured != null)
                    viewModel.FeaturedItem = new ItemViewModel(category.Featured);

                viewModel.Items = new List<Item>(category.Items.Skip(0).Take(10)); // TODO: Pagination

                viewModel.Subcategories = new List<Category>(category.Children);
                viewModel.ParentCategory = category.ParentCategory;
            }
            return View(viewModel);
        }
    }
}
