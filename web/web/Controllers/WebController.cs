using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkdownSharp;
using web.Models;

namespace web.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Maps()
        {
            Markdown md = new Markdown();
            var viewModel = new TopLevelCategoryViewModel();
            viewModel.FeaturedItem = new FeaturedItemViewModel();
            viewModel.FeaturedItem.Name = "Team Fortress 2: 2fort";
            viewModel.FeaturedItem.Id = new Guid("55043B53-0E60-4394-9821-E33D3D4AC4B9");
            viewModel.FeaturedItem.Description = md.Transform("SethBling and Hypixel's latest multiplayer collaboration.\n\n[YouTube](http://youtu.be/NmlqBKGfQ9I)");
            viewModel.FeaturedItem.Image = "/Data/Maps/Images/testFeature.png";
            return View(viewModel);
        }
    }
}
