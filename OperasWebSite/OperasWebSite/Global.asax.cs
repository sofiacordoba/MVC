using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;  //agregar
using OperasWebSite.Data; //agregar
using OperasWebSite.Initializers; //agregar 

namespace OperasWebSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
       
        protected void Application_Start()
        {
            //Database.SetInitializer<OperasDBContext>(new OperasInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
