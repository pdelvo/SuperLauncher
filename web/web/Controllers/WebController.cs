using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Service.Model;

namespace web.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Index()
        {
            using (var database = new DatabaseEntities())
            {
                if (!database.Users.Any())
                    return RedirectToAction("CreateAdministrator");
            }
            return View();
        }

        public ActionResult CreateAdministrator()
        {
            using (var database = new DatabaseEntities())
            {
                if (database.Users.Any())
                {
                    Response.StatusCode = 403;
                    return null;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdministrator(CreateAdministratorViewModel viewModel)
        {
            using (var database = new DatabaseEntities())
            {
                if (database.Users.Any())
                {
                    Response.StatusCode = 403;
                    return null;
                }
            }
            if (!ModelState.IsValid)
                return View(viewModel);
            bool success = DatabaseAuthentication.CreateUser(
                viewModel.Username, viewModel.Email, viewModel.Password, true);
            if (!success)
                return View(viewModel);
            return RedirectToAction("Index");
        }
    }
}
