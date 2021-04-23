using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperasWebSite.Filters;

namespace OperasWebSite.Controllers
{

    [MyfilterTest]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Debug.WriteLine("ejecutando INDEX");

            ViewBag.Message = "Test controller";
            ViewBag.ServerTime = DateTime.Now;
            return View("Index");
        }

        //GET: Home/Form
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(FormCollection formulario)
        {
            var name = formulario[0].ToString();
            var address = formulario["Address"].ToString();
            var gender = formulario["Gender"].ToString();
            var isMarried = formulario["IsMarried"].ToString();
            var country = formulario["country"].ToString();
            var password = formulario["Password"].ToString();

            return View();
        }


        //GET/HOME/SomeError
        //[HandleError()]
        public ActionResult SomeError()
        {
            //try
            //{
            var num2 = 0;
            var result = 5 / num2;
            return View(result);
            
             //}
             //catch (Exception ex)
             //{
             //    return View("Error");
             //}
            
        }



        //se llama antes de ejecutar el método de acción (Index)
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("se llama antes de ejecutar el método de acción");
        }

        //se llama después de ejecutar el método de acción (Index)
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("se llama después de ejecutar el método de acción");
        }


        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    //base.OnException(filterContext);
        //    Exception ex = filterContext.Exception;
        //    filterContext.ExceptionHandled = true;

        //    var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

        //    filterContext.Result = new ViewResult()
        //    {
        //        ViewName = "Error",
        //        ViewData = new ViewDataDictionary(model)
        //    };
        //}


    }
}