using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsWeb.Models
{
    public class Product
    {
        [Required]
        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string ProductNumber { get; set; }
        [Required]
        public int SafetyStockLevel { get; set; }
        [Required]
        public decimal StandardCost { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        [StringLength(50)]
        public string Size { get; set; }
        [StringLength(10)]
        public string ProductLine { get; set; }
        public int ProductSubcategoryID { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
    }
}