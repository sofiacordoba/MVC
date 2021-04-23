using ProductsWeb.Data;
using ProductsWeb.Models;
using ProductsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsWeb.Controllers
{
    public class ProductSubCategoryController : Controller
    {

        private ProductDBContext context = new ProductDBContext();
        
        public ActionResult Index()
        {
            return View(AdminProductSubCategory.GetSubCategories());
        }

        public ActionResult TraerPorId(int id) {
            ProductSubCategory subCategory = AdminProductSubCategory.GetSubCategory(id);
            if (subCategory == null) {
                return HttpNotFound();
            }
            return View("TraerPorId", subCategory);
        }

        public ActionResult Create() {
            ProductSubCategory subCategory = new ProductSubCategory();
            return View("Create",subCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductSubCategory subCategory) {
            //subCategory.ProductCategory = AdminProductCategory.GetCategory(subCategory.ProductCategoryID);
            //subCategory.Productos=context.Products.ToList();
            //subCategory.ProductSubcategoryID = context.SubCategories.ToList().Last().ProductSubcategoryID+1;
            if (ModelState.IsValid) {
                AdminProductSubCategory.Create(subCategory);
                return RedirectToAction("Index");
            } else {
                return View("Create", subCategory);
            }
        }

        public ActionResult Edit(int id) {
            return View(AdminProductSubCategory.GetSubCategory(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductSubCategory NuevaSubCategory) {         
            if (ModelState.IsValid) {
                AdminProductSubCategory.Update(NuevaSubCategory);
                return RedirectToAction("Index");
            } else {
                return View("Edit");
            }
        }

        public ActionResult Delete(int id) {
            return View(AdminProductSubCategory.GetSubCategory(id));
        }

        [HttpPost]
        public ActionResult Delete(int id,ProductSubCategory productSub) {
            ProductSubCategory subCategory = context.SubCategories.Find(id);
            if (subCategory != null) {
                AdminProductSubCategory.Delete(subCategory.ProductSubcategoryID);
            }
            return RedirectToAction("Index");
        }

    }
}