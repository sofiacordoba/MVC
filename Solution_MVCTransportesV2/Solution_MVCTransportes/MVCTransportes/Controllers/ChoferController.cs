using MVCTransportes.Data;
using MVCTransportes.Models;
using MVCTransportes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTransportes.Controllers
{
    public class ChoferController : Controller
    {        
        // GET: Chofer
        public ActionResult Index()
        {            
            return View("Index", AdminChofer.ListarChoferes());
        }
        //GET: Chofers/Create
        [HttpGet]
        public ActionResult Create()
        {
            Chofer chofer = new Chofer();
            return View(chofer);
        }
        //POST: Chofers/Create
        [HttpPost]
        public ActionResult Create(Chofer chofer)
        {
            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                AdminChofer.CargarChofer(chofer);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", chofer);
            }
        }
        public ActionResult Delete(int id)
        {
            var chofer = AdminChofer.TraerChofer(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View("Delete", chofer);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var chofer = AdminChofer.TraerChofer(id);
            AdminChofer.EliminarChofer(chofer);
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            Chofer Chofer = AdminChofer.TraerChofer(id);
            if (Chofer == null)
            {
                return HttpNotFound();
            }
            return View("Details", Chofer);
        }
        public ActionResult GetChofer(int id)
        {
            Chofer Chofer = AdminChofer.TraerChofer(id);
            if (Chofer != null)
            {
                return View("Details", Chofer);
            }
            else
            {
                return null;
            }

        }
        //GET: Chofers/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Chofer ChoferDB = AdminChofer.TraerChofer(id);

            return View(ChoferDB);
        }
        //POST: Chofers/Edit
        [HttpPost]
        public ActionResult Edit(Chofer chofer)
        {
            //buscamos en memoria
            Chofer ChoferDB = AdminChofer.TraerChofer(chofer.ChoferId);

            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                AdminChofer.Actualizar(ChoferDB, chofer);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", ChoferDB);
            }
        }


    }
}