using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperasWebSite.Filters
{
    public class MyfilterTest : ActionFilterAttribute
    {

        //se llama antes de ejecutar el método de acción
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("se llama antes de ejecutar el método de acción");
        }
        //se llama después de invocar al método de acción
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("se llama después de invocar al método de acción");
        }
    }
}
