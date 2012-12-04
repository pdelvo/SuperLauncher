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
    public class WebController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
