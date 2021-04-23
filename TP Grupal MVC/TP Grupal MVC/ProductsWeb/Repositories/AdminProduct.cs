using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsWeb.Data;
using ProductsWeb.Models;

namespace ProductsWeb.Repositories
{
    public static class AdminProduct
    {
        private static ProductDBContext context = new ProductDBContext();

        public static List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public static List<Product> GetProducts(string color)
        {
            return context.Products.Where(x=>x.Color == color).ToList();
        }

        public static List<Product> GetProducts(int category)
        {
            return context.Products.Where(x => x.ProductSubcategoryID == category).ToList();
        }

        public static Product GetProduct(int id)
        {
            Product product = (from a in context.Products where a.ProductID == id select a).Single();
            return product;
        }

        public static List<Product> GetProductNumber(string productNumber)
        {
            List<Product> product = (from a in context.Products where a.ProductNumber == productNumber select a).ToList();
            return product;
            
        }

        public static int Create(Product product)
        {
            context.Products.Add(product);
            int result = context.SaveChanges();

            return result;
        }

        public static int Update(Product product)
        {
            Product a = context.Products.Find(product.ProductID);
            int result = -1;

            if (a != null)
            {
                a.Name = product.Name;
                a.ProductNumber = product.ProductNumber;
                a.SafetyStockLevel = product.SafetyStockLevel;
                a.StandardCost = product.StandardCost;
                a.ListPrice = product.ListPrice;
                a.ModifiedDate = product.ModifiedDate;
                a.Size = product.Size;
                a.ProductLine = product.ProductLine;
                a.DiscontinuedDate = product.DiscontinuedDate;
                a.Color = product.Color;
                result = context.SaveChanges();
            }
            return result;
        }
        public static int Delete(int id)
        {
            Product product = context.Products.Find(id);
            int result = -1;

            if (product != null)
            {
                context.Products.Remove(product);
                result = context.SaveChanges();
            }
            return result;
        }

        
    }
}