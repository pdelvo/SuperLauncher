using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;
using System.Web.Security;

namespace web.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index(int id)
        {
            ItemViewModel viewModel;
            using (var database = new DatabaseEntities())
            {
                var item = from i in database.Items
                           where i.Id == id
                           select i;
                if (item.Any())
                    return new HttpNotFoundResult();
                viewModel = new ItemViewModel(item.FirstOrDefault());
            }
            return View(viewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
