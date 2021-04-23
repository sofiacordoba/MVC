using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;//agregar

namespace OperasWebSite.Models
{
    public class OperasInitializer:DropCreateDatabaseAlways<OperaDbContext>
    {
        protected override void Seed(OperaDbContext context)
        {
            var operas = new List<Opera>() 
            { 
            new Opera(){  Title="Cosi Fan Tutte", Composer="Mozart", Year=1970 }
            
            };
        }
    }
}