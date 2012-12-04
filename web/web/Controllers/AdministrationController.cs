using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/
        public ActionResult Index()
        {
            return View();
        }
    }
}
