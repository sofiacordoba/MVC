using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SistemaWebClinica.Models;

namespace SistemaWebClinica.Data
{
    public class MedicoDBContext : DbContext
    {
        public MedicoDBContext() : base("keydbmedico") { }

        public DbSet<Medico> Medicos { get; set; }
    }
}