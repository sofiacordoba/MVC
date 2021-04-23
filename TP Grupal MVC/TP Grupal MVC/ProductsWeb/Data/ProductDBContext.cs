using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProductsWeb.Models;

namespace ProductsWeb.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("keydbproduct") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductSubCategory> SubCategories { get; set; }
    }
}