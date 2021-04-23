using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;   //agregar
using OperasWebSite.Data;  //agregar
using OperasWebSite.Models; //agregar

namespace OperasWebSite.Initializers
{
    public class OperasInitializer : DropCreateDatabaseAlways<OperasDBContext>
    {
        protected override void Seed(OperasDBContext context)
        {

            var operas = new List<Opera>
            {
                new Opera() {Title="Cosi Fan Tutte" , Year=1790, Composer="Mozart"}
            };

            operas.ForEach(s => context.Operas.Add(s));  // s es un item

            context.SaveChanges();  //mandamos la operación a la base
        }

    }
}