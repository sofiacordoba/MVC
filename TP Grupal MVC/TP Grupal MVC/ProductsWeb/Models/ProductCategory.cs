using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsWeb.Models
{
    public class ProductCategory
    {
        public List<ProductSubCategory> Subcategories { get; set; }
        [Required]
        [Key]
        public int ProductCategoryID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}