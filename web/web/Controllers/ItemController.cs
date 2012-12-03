using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownSharp;
using web.Models;

namespace web.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/id
        public ActionResult Index(Guid id)
        {
            var md = new Markdown();
            var viewModel = new ItemDetailsViewModel();
            viewModel.ItemName = "Team Fortress 2: 2fort";
            viewModel.Id = new Guid("55043B53-0E60-4394-9821-E33D3D4AC4B9");
            viewModel.Description = md.Transform("SethBling and Hypixel's latest multiplayer collaboration.\n\n[YouTube](http://youtu.be/NmlqBKGfQ9I)");
            viewModel.Image = "/Data/Maps/Images/testFeature.png";
            return View(viewModel);
        }

        public JsonResult Details(Guid id)
        {
            var md = new Markdown();
            return Json(new
            {
                id = id,
                name = "Team Fortress 2: 2fort",
                description = md.Transform("SethBling and Hypixel's latest multiplayer collaboration.\n\n[YouTube](http://youtu.be/NmlqBKGfQ9I)"),
                download = "/data/maps/download/" + id.ToString() + ".zip",
                type = "map"
            });
        }
    }
}
