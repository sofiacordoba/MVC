using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //agregar EntityFramework
using OperasWebSite.Models; //agregar


namespace OperasWebSite.Data     //acá configuramos la de cadena de conexión
{
    public class OperasDBContext : DbContext
    {
        public OperasDBContext() : base("Data Source=.;Initial Catalog=dboperastest;Integrated Security=True") { }

        public DbSet<Opera> Operas { get; set; }
    }
}