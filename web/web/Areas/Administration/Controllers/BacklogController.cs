using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;

namespace web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BacklogController : Controller
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
    }
}
