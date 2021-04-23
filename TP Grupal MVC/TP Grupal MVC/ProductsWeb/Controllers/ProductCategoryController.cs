using ProductsWeb.Models;
using ProductsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsWeb.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            List<ProductCategory> categories = AdminProductCategory.GetCategories();
            return View(categories);
        }

        // GET: ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            ProductCategory category = AdminProductCategory.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View("Details", category);
        }

        // GET: ProductCategory/Create
        public ActionResult Create()
        {
            ProductCategory category = new ProductCategory();

            return View("Create", category);
        }

        // POST: ProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", category);
            }
            else
            {
                AdminProductCategory.Create(category);
                return RedirectToAction("Index");
            }
        }

        // GET: ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            ProductCategory category = AdminProductCategory.GetCategory(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View("Edit", category);
        }

        // POST: ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", category);
            }
            else
            {
                AdminProductCategory.Update(category);
                return RedirectToAction("Index");
            }
        }

        // GET: ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            ProductCategory category = AdminProductCategory.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View("Delete", category);
        }

        // POST: ProductCategory/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminProductCategory.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
