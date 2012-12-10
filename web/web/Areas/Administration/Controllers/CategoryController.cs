using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Areas.Administration.Models;
using web.Models;
using web.Service.Model;

namespace web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new NestedCategoryDescriptor();
            using (var database = new DatabaseEntities())
            {
                viewModel.Subcategories = new List<NestedCategoryDescriptor>();
                foreach (var category in database.Categories.Where(c => c.Parent == null))
                    viewModel.Subcategories.Add(GenerateCategory(category));
            }
            return View(viewModel);
        }

        private NestedCategoryDescriptor GenerateCategory(Category category)
        {
            var descriptor = new NestedCategoryDescriptor();
            descriptor.Name = category.Name.Trim();
            descriptor.Id = category.Id;
            descriptor.Subcategories = new List<NestedCategoryDescriptor>();

            foreach (var subcategory in category.Children)
                descriptor.Subcategories.Add(GenerateCategory(subcategory));
            return descriptor;
        }

        public ActionResult Add()
        {
            var viewModel = new AddCategoryViewModel();
            int parentId;
            if (Request.QueryString["parent"] != null &&
                int.TryParse(Request.QueryString["parent"], out parentId))
            {
                Category parent;
                using (var database = new DatabaseEntities())
                {
                    parent = database.CategoryById(parentId);
                }
                if (parent != null)
                {
                    viewModel.Parent = parentId;
                    viewModel.ParentName = parent.Name;
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var category = new Category
            {
                Name = viewModel.Name,
                Parent = viewModel.Parent
            };
            using (var database = new DatabaseEntities())
            {
                database.Categories.AddObject(category);
                database.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Item)
        {
            // TODO: Move all items under this category to parent category
            using (var database = new DatabaseEntities())
            {
                var category = database.CategoryById(Item);
                if (category != null)
                {
                    database.DeleteObject(category);
                    database.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Rename(int Id, string NewName)
        {
            using (var database = new DatabaseEntities())
            {
                var category = database.CategoryById(Id);
                category.Name = NewName;
                database.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Feature(int Id)
        {
            using (var database = new DatabaseEntities())
            {
                var category = database.CategoryById(Id);
                return View(new CategoryViewModel(category));
            }
        }

        public ActionResult SetFeature(int Id, int Item)
        {
            using (var database = new DatabaseEntities())
            {
                var category = database.CategoryById(Id);
                category.FeaturedItem = Item;
                database.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
