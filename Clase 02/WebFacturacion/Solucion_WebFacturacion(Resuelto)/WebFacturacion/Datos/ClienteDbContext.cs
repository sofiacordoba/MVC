using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebFacturacion.Models;

namespace WebFacturacion.Datos
{
    public class ClienteDbContext: DbContext
    {
        public ClienteDbContext() : base("keydb") { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}