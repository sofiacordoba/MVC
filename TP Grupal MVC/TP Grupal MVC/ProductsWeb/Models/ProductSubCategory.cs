using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductsWeb.Models
{
    public class ProductSubCategory
    {
        [Key]
        public int ProductSubcategoryID { get; set; }
        public List<Product> Productos { get; set; }
        [Required]
        public int ProductCategoryID { get; set; }
        [Required]
        [NotMapped]
        public ProductCategory ProductCategory { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}