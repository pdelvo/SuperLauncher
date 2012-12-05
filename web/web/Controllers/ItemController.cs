using System;
using System.Collections.Generic;
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
            var blob = new Blob
            {
                DownloadUrl = "/data/" + user.UserName + "/" + newName
            };
            item.Blobs.Add(blob);
            
            return Json(new { success = true });
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
    }
}
