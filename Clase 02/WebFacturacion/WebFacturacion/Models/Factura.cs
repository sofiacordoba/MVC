using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacion.Models
{
    public class Factura
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int IdCliente { get; set; }
    }
}