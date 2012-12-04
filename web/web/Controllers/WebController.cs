using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
