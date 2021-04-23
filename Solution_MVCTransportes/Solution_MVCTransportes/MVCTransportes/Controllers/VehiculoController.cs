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
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            return View("Index", AdminVehiculo.ListarVehiculos());
        }
        //GET: Vehiculos/Create
        [HttpGet]
        public ActionResult Create()
        {
            Vehiculo Vehiculo = new Vehiculo();
            return View(Vehiculo);
        }
        //POST: Vehiculos/Create
        [HttpPost]
        public ActionResult Create(Vehiculo Vehiculo)
        {
            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                AdminVehiculo.CargarVehiculo(Vehiculo);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", Vehiculo);
            }
        }
        public ActionResult Delete(string id)
        {
            var Vehiculo = AdminVehiculo.TraerVehiculo(id);
            if (Vehiculo == null)
            {
                return HttpNotFound();
            }
            return View("Delete", Vehiculo);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var vehiculo = AdminVehiculo.TraerVehiculo(id);
            AdminVehiculo.EliminarVehiculo(vehiculo);
            return RedirectToAction("Index");

        }
        public ActionResult Details(string id)
        {
            Vehiculo Vehiculo = AdminVehiculo.TraerVehiculo(id);
            if (Vehiculo == null)
            {
                return HttpNotFound();
            }
            return View("Details", Vehiculo);
        }
        public ActionResult GetVehiculo(string id)
        {
            Vehiculo Vehiculo = AdminVehiculo.TraerVehiculo(id);
            if (Vehiculo != null)
            {
                return View("Details", Vehiculo);
            }
            else
            {
                return null;
            }

        }
        //GET: Vehiculos/Edit
        [HttpGet]
        public ActionResult Edit(string id)
        {
            Vehiculo VehiculoDB = AdminVehiculo.TraerVehiculo(id);

            return View(VehiculoDB);
        }
        //POST: Vehiculos/Edit
        [HttpPost]
        public ActionResult Edit(Vehiculo Vehiculo)
        {
            //buscamos en memoria
            Vehiculo VehiculoDB = AdminVehiculo.TraerVehiculo(Vehiculo.Matricula);

            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                AdminVehiculo.Actualizar(VehiculoDB, Vehiculo);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", VehiculoDB);
            }
        }


    }
}