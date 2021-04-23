using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFacturacion.Models
{
    public class Detalle
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Factura Factura { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}