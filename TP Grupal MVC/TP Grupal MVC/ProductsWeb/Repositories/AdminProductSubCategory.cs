using ProductsWeb.Data;
using ProductsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsWeb.Repositories {
    public class AdminProductSubCategory {
        private static ProductDBContext context = new ProductDBContext();

        public static List<ProductSubCategory> GetSubCategories() {
            return context.SubCategories.ToList();
        }

        public static ProductSubCategory GetSubCategory(int id) {
            ProductSubCategory subcategory = (from a in context.SubCategories where a.ProductSubcategoryID == id select a).Single();
            return subcategory;
        }

        public static int Create(ProductSubCategory subcategory) {
            context.SubCategories.Add(subcategory);
            int result = context.SaveChanges();

            return result;
        }
        public static int Update(ProductSubCategory subcategory) {
            ProductSubCategory subcat = context.SubCategories.Find(subcategory.ProductSubcategoryID);
            int result = -1;

            if (subcat != null) {
                subcat.Name = subcategory.Name;
                subcat.ModifiedDate = subcategory.ModifiedDate;
                subcat.ProductCategory = subcategory.ProductCategory;
                subcat.ProductCategoryID = subcategory.ProductCategoryID;
                subcat.Productos = subcategory.Productos;                

                result = context.SaveChanges();
            }
            return result;
        }

        public static int Delete(int id) {
            ProductSubCategory subcategory = context.SubCategories.Find(id);
            int result = -1;

            if (subcategory != null) {
                context.SubCategories.Remove(subcategory);
                result = context.SaveChanges();
            }
            return result;
        }
        public static Product GetProduct(ProductSubCategory subCategory) {            
            return context.Products.Where(x => x.ProductSubcategoryID == subCategory.ProductSubcategoryID).Single();
        }

    }
}