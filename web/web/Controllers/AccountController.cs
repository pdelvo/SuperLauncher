using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using web.Models;

namespace web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogIn()
        {
            if (Membership.GetAllUsers().Count == 0)
                return RedirectToAction("CreateAdministrator");
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            if (!Membership.ValidateUser(viewModel.Username, viewModel.Password))
            {
                viewModel.Password = "";
                viewModel.ErrorMessage = "Username or password incorrect.";
                return View(viewModel);
            }
            var user = Membership.GetUser(viewModel.Username, true);
            Session["user"] = user;
            FormsAuthentication.SetAuthCookie(viewModel.Username, viewModel.RememberMe);
            return RedirectToAction("Index", "Web");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Web");
        }

        public ActionResult CreateAdministrator()
        {
            if (Membership.GetAllUsers().Count != 0)
                return new HttpUnauthorizedResult();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdministrator(CreateAdministratorViewModel viewModel)
        {
            if (Membership.GetAllUsers().Count != 0)
                return new HttpUnauthorizedResult();
            if (!ModelState.IsValid)
                return View(viewModel);

            MembershipCreateStatus status;

            var user = Membership.CreateUser(viewModel.Username, viewModel.Password,
                viewModel.Email, null, null, true, null, out status);
            if (status != MembershipCreateStatus.Success)
                return View(viewModel);
            user.LastActivityDate = DateTime.Now;
            Roles.AddUserToRole(viewModel.Username, "Administrator");

            FormsAuthentication.SetAuthCookie(viewModel.Username, viewModel.RememberMe);
            return RedirectToAction("Index", "Web");
        }
    }
}
