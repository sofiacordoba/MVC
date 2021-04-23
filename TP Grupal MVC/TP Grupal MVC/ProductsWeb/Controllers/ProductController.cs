using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsWeb.Models;
using ProductsWeb.Repositories;

namespace ProductsWeb.Controllers
{
    public class ProductController : Controller
    {
        /*
        i.TraerPorColor
        ii.TraerPorSubcategoria
        iii.TraerPorNumeroProducto
        */
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = AdminProduct.GetProducts();
            return View(products);
        }


        //public ActionResult TraerPorColor()
        //{
        //    List<Product> products = AdminProduct.GetProducts();
        //    return View("TraerPorColor",products);
        //}


        public ActionResult TraerPorColor(string color)
        {
            List<Product> products = AdminProduct.GetProducts(color);

            if (products == null)
            {
                return HttpNotFound();
            }
            return View("TraerPorColor",products);
        }


        /*public ActionResult TraerPorCategory(int category)
        {
            List<Product> products = AdminProduct.GetProducts(category);

            if (products == null)
            {
                return HttpNotFound();
            }
            return View("TraerPorCategory", products);
        }*/

        public ActionResult TraerPorCategory(int id)
        {
            List<Product> products = AdminProduct.GetProducts(id);

            if (products == null)
            {
                return HttpNotFound();
            }
            return View("TraerPorCategory", products);
        }



        public ActionResult Create()
        {
            Product newProduct = new Product();

            return View("Create", newProduct);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", product);
            }
            else
            {
                AdminProduct.Create(product);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            Product product = AdminProduct.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Delete", product);

        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminProduct.Delete(id);

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Product product = AdminProduct.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Details", product);
        }

        public ActionResult DetailsPorProductNumber(string productNumber)
        {
            List<Product> product = AdminProduct.GetProductNumber(productNumber);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("DetailsPorProductNumber", product);

        }

        public ActionResult Edit(int id)
        {
            Product product = AdminProduct.GetProduct(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Edit", product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", product);
            }
            else
            {
                AdminProduct.Update(product);
                return RedirectToAction("Index");
            }
        }

    }
}