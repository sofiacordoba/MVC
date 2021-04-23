using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;//Agregar

namespace OperasWebSite.Models
{
    public class OperaDbContext:DbContext
    {
        public OperaDbContext() : base("keydbOpera") { }

        public DbSet<Opera> Operas { get; set; }
    }
}