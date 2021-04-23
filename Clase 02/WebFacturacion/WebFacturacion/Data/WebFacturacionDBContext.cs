using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //agregar
using WebFacturacion.Models; //agregar

namespace WebFacturacion.Data
{
    public class WebFacturacionDBContext : DbContext
    {
        public WebFacturacionDBContext() : base("DBWebFacturacion") { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}