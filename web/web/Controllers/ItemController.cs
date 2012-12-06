using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;
using System.Web.Security;
using System.IO;
using IOFile = System.IO.File;

namespace web.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index(int id)
        {
            ItemViewModel viewModel;
            using (var database = new DatabaseEntities())
            {
                var item = database.ItemById(id);
                if (item != null)
                    return HttpNotFound();
                viewModel = new ItemViewModel(item);
            }
            return View(viewModel);
        }

        public ActionResult JsonSearch(string query)
        {
            List<object> jsonItems = new List<object>();
            using (var database = new DatabaseEntities())
            {
                var items = (from i in database.Items
                        where i.Name.ToUpper().Contains(query.ToUpper()) ||
                                i.Description.ToUpper().Contains(query.ToUpper())
                        select i).Take(10).ToArray();
                foreach (var item in items)
                {
                    jsonItems.Add(new
                    {
                        id = item.Id,
                        name = item.Name,
                        user = item.User
                    });
                }
            }
            return Json(jsonItems.ToArray(), JsonRequestBehavior.AllowGet);
        }

        #region Adding Content

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(AddItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var item = new ItemInProgress
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };
            Session["workingItem"] = item;
            switch (viewModel.Type)
            {
                case "Maps":
                    item.ItemType = ItemType.Map;
                    return RedirectToAction("AddMap");
                default:
                    return RedirectToAction("Add");
            }
        }

        [Authorize]
        public ActionResult AddMap()
        {
            var item = Session["workingItem"] as ItemInProgress;
            if (item == null || item.ItemType != ItemType.Map)
                return RedirectToAction("Add");
            return View(item);
        }

        [Authorize]
        public ActionResult Dependencies()
        {
            // TODO
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult UploadFile()
        {
            var item = Session["workingItem"] as ItemInProgress;
            if (item == null || item.ItemType == ItemType.Server)
                return Json(new { success = false });
            if (item.Blobs.Count != 0)
                return Json(new { success = false });

            var reader = new StreamReader(Request.InputStream);
            var base64 = reader.ReadToEnd();
            byte[] file = Convert.FromBase64CharArray(base64.ToCharArray(), 0, base64.Length);
            var name = Request.Headers["x-file-name"];
            var user = Membership.GetUser();

            // Check user directories
            var path = Path.Combine(Server.MapPath("~"), "data", user.UserName);
            Directory.CreateDirectory(path);
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            int i = 1;
            string newName = name;
            string extension = Path.GetExtension(newName);
            newName = Path.GetFileNameWithoutExtension(newName);
            while (IOFile.Exists(Path.Combine(path, newName + extension)))
                newName = Path.GetFileNameWithoutExtension(name) + i++;
            IOFile.WriteAllBytes(Path.Combine(path, newName + extension), file);

            // Add blob
            var blob = new WorkingItemBlob
            {
                DownloadUrl = "/data/" + user.UserName + "/" + newName,
                Name = Request.Headers["x-file-name"]
            };
            item.Blobs.Add(blob);

            return Json(new { success = true });
        }

        [Authorize]
        public ActionResult ReviewItem()
        {
            var item = Session["workingItem"] as ItemInProgress;
            if (item == null)
                return RedirectToAction("Add");
            var viewModel = new ReviewItemViewModel();
            viewModel.Item = item;
            viewModel.Categories = new List<string>();
            using (var database = new DatabaseEntities())
            {
                switch (item.ItemType)
                {
                    case ItemType.Map:
                        viewModel.Categories = new List<string>(
                            from c in database.CategoryByName("Maps").Children
                            select c.Name);
                        break;
                }
            }
            viewModel.Categories.Insert(0, "None");
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ReviewItem(ReviewItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var item = Session["workingItem"] as ItemInProgress;
            if (item == null || Request.Form["category"] == null)
                return RedirectToAction("Add");

            Item dbItem;
            using (var database = new DatabaseEntities())
            {
                Category category = database.CategoryByName(Request.Form["category"]);
                if (category != null)
                {
                    switch (item.ItemType)
                    {
                        case ItemType.Map:
                            if (!database.CategoryByName("Maps").Children.Contains(category))
                                return RedirectToAction("Add");
                            break;
                    }
                }
                dbItem = new Item();
                dbItem.Name = item.Name;
                dbItem.Description = item.Description;
                dbItem.User = Membership.GetUser().UserName;
                if (category != null)
                    dbItem.CategoryId = category.Id;
                dbItem.FriendlyVersion = viewModel.Version;
                // TODO: Images
                dbItem.Version = 0;
                dbItem.Approved = false;
                dbItem.Type = item.ItemType.ToString();
                database.Items.AddObject(dbItem);
                database.SaveChanges();
                // Add blobs
                foreach (var blob in item.Blobs)
                {
                    var dbBlob = new Blob();
                    dbBlob.DownloadUrl = blob.DownloadUrl;
                    dbBlob.DestinationPath = GetLocalPathForBlob(blob, item);
                    dbBlob.ItemId = dbItem.Id;
                    database.Blobs.AddObject(dbBlob);
                }

                // Add dependencies
                foreach (var dependency in item.Dependencies)
                {
                    var dbDependency = new Dependency();
                    dbDependency.DependencyItem = dependency.Id;
                    dbDependency.DependentItem = dbItem.Id;
                    database.Dependencies.AddObject(dbDependency);
                }
                database.SaveChanges();
            }

            return RedirectToAction("Index", "Web");
        }

        private string GetLocalPathForBlob(WorkingItemBlob blob, ItemInProgress item)
        {
            switch (item.ItemType)
            {
                case ItemType.Map:
                    return Path.Combine("saves", Path.GetFileName(blob.DownloadUrl));
                default:
                    return null;
            }
        }

        #endregion

        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Item item;
            using (var database = new DatabaseEntities())
                item = database.ItemById(id);
            if (item == null)
                return HttpNotFound();
            var user = Membership.GetUser();
            if (user.UserName == item.User || Roles.GetRolesForUser(user.UserName).Contains("Administrator"))
            {
                using (var database = new DatabaseEntities())
                    database.DeleteObject(item);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Approve(int id)
        {
            using (var database = new DatabaseEntities())
            {
                var item = database.ItemById(id);
                item.Approved = true;
                database.SaveChanges();
            }
            return Redirect("/Administration/Backlog");
        }
    }
}
