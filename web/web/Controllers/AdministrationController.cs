using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;

namespace web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new BacklogViewModel();
            using (var database = new DatabaseEntities())
            {
                viewModel.Backlog = new List<Item>(
                    from i in database.Items
                    where !i.Approved
                    select i);
            }
            return View(viewModel);
        }

        public ActionResult Categories()
        {
            return null;
        }
    }
}
