using MVCTransportes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTransportes.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("keydb") { }

        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}