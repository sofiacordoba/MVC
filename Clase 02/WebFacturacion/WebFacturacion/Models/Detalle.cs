using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacion.Models
{
    public class Detalle
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public string Descripcion{ get; set; }

    }
}