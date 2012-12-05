using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using web.Models;
using web.Shared;

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
            return Redirect(Request.QueryString["ReturnUrl"]);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Web");
        }

        public ActionResult CreateAdministrator()
        {
            if (Membership.GetAllUsers().Count != 0) // This page is only accessible with no registered users in the db
                return new HttpUnauthorizedResult();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdministrator(CreateAccountViewModel viewModel)
        {
            if (Membership.GetAllUsers().Count != 0) // This page is only accessible with no registered users in the db
                return new HttpUnauthorizedResult();
            if (!ModelState.IsValid)
                return View(viewModel);

            MembershipCreateStatus status;

            var user = Membership.CreateUser(viewModel.Username, viewModel.Password,
                viewModel.Email, null, null, true, null, out status);
            if (status != MembershipCreateStatus.Success)
                return View(viewModel);
            user.LastActivityDate = DateTime.Now;
            if (!Roles.GetAllRoles().Contains("Administrator"))
                Roles.CreateRole("Administrator");
            Roles.AddUserToRole(viewModel.Username, "Administrator");

            FormsAuthentication.SetAuthCookie(viewModel.Username, viewModel.RememberMe);
            return RedirectToAction("Index", "Web");
        }

        public ActionResult CreateAccount()
        {
            return View(new CreateAccountViewModel());
        }

        [HttpPost]
        public ActionResult CreateAccount(CreateAccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            string error;
            if (!Recapcha.ValidateCapcha(Request, Request.Form["recaptcha_challenge_field"],
                                    Request.Form["recaptcha_response_field"], out error))
            {
                viewModel.CapchaError = error;
                return View(viewModel);
            }

            MembershipCreateStatus status;

            var user = Membership.CreateUser(viewModel.Username, viewModel.Password,
                viewModel.Email, null, null, true, null, out status);
            if (status != MembershipCreateStatus.Success)
                return View(viewModel);
            user.LastActivityDate = DateTime.Now;

            FormsAuthentication.SetAuthCookie(viewModel.Username, viewModel.RememberMe);
            return RedirectToAction("Index", "Web");
        }
    }
}
