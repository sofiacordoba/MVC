using ProductsWeb.Data;
using ProductsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsWeb.Repositories
{
    public static class AdminProductCategory
    {
        private static ProductDBContext context = new ProductDBContext();

        public static List<ProductCategory> GetCategories()
        {
            return context.Categories.ToList();
        }

        public static ProductCategory GetCategory(int id)
        {
            ProductCategory category = (from a in context.Categories where a.ProductCategoryID== id select a).Single();
            return category;
        }
        public static int Create(ProductCategory category)
        {
            context.Categories.Add(category);
            int result = context.SaveChanges();

            return result;
        }

        public static int Update(ProductCategory category)
        {
            ProductCategory cat = context.Categories.Find(category.ProductCategoryID);
            int result = -1;

            if (cat != null)
            {
                cat.Name = category.Name;
                cat.ModifiedDate = category.ModifiedDate;
                cat.Subcategories = category.Subcategories;

                result = context.SaveChanges();
            }
            return result;
        }
        public static int Delete(int id)
        {
            ProductCategory category = context.Categories.Find(id);
            int result = -1;

            if (category != null)
            {
                context.Categories.Remove(category);
                result = context.SaveChanges();
            }
            return result;
        }
    }
}