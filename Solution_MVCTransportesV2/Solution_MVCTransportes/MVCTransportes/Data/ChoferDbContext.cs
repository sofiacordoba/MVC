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
        public MyDbContext() : base("keydb")
        {

            //Cargar sus vehiculos
            //
            foreach (var item in Choferes.ToList())
            {
                //todavia no estan cargados los vehiculos
                
                try
                {
                    item.Vehiculo = Vehiculos.ToList().SingleOrDefault(x => x.ChoferID == item.ChoferId);

                }
                catch (Exception)
                {


                }
            }
            foreach (var vehiculo in Vehiculos.ToList())
            {
                try
                {
                    vehiculo.Chofer = Choferes.SingleOrDefault(x=>x.ChoferId == vehiculo.ChoferID) ;

                }
                catch (Exception)
                {

                  
                }
            }
        }

        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}