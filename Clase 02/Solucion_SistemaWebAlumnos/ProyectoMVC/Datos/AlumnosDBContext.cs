using ProyectoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Datos
{
    public class AlumnosDBContext : DbContext
    {
        public AlumnosDBContext() : base("keyDB") { }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}