using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;
using System.Web.Security;
using System.Configuration;

namespace web.Controllers
{
    public class RepoController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var viewModel = new WebIndexViewModel();
            using (var database = new DatabaseEntities())
            {
                var user = Membership.GetUser();
                viewModel.Items = new List<Item>(
                    from i in database.Items
                    where i.User == user.UserName &&
                        i.UpdatesItem == null
                    select i);
            }
            
            return View(viewModel);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
