using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperasWebSite.Models; //agregar
using OperasWebSite.Data;  //agregar

namespace OperasWebSite.Controllers
{
    //[MyFilterTest]
    [Authorize]
    public class OperasController : Controller
    {
        //declarar e instanciar a EntityFramework
        private OperasDBContext context = new OperasDBContext();

        // GET: Operas


        public ActionResult Index()  //la view se llama Index por default
        {
            //usamos EF para traer la coleccion de operas
            List<Opera> operas = context.Operas.ToList();

            //enviamos a la vista Index la lista de operas
            return View("Index", operas);  
        }

        //GET: Operas/Create
        public ActionResult Create()
        {
            Opera opera = new Opera();
            return View(opera); // si no le digo nada, la vista se llama como el metodo ( Create())
        }

        //POST: Operas/Create
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            //valiar las propiedades del modelo
            if (ModelState.IsValid)
            {
                //guardamos en memoria
                context.Operas.Add(opera);

                //guardamos en la base de datos
                context.SaveChanges();
                
                //vamos a la acción index()
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", opera);
            }
        }
    }
}