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
    public class ItemController : Controller
    {
        public ActionResult Item(int id)
        {
            ItemViewModel viewModel;
            using (var database = new DataEntities())
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
            using (var database = new DataEntities())
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
    }
}
