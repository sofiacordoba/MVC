using SistemaWebClinica.Models;
using SistemaWebClinica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebClinica.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            List<Medico> medicos = AdminMedico.GetMedicos();
            return View(medicos);
        }


        public ActionResult TraerPorEspecialidad(string especialidad)
        {
            List<Medico> medicos = AdminMedico.GetMedicosEsp(especialidad);

            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View("TraerPorEspecialidad", medicos);
        }


        public ActionResult TraerPorEspecialidadCiudad(string especialidad, string ciudad)
        {
            List<Medico> medicos = AdminMedico.GetMedicosEspyCiudad(ciudad, especialidad);

            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View("TraerPorEspecialidad", medicos);
        }

        // GET: Medico/Create
        public ActionResult Create()
        {
            Medico newMedico = new Medico();

            return View("Create", newMedico);
        }

        // POST: Medico/Create
        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", medico);
            }
            else
            {
                AdminMedico.Create(medico);
                return RedirectToAction("Index");
            }
        }


         //GET: Medico/Details/2
        public ActionResult Details(int id)
        {
            Medico medico = AdminMedico.GetMedico(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
           return View("Details", medico);
        }


         //GET: Medico/Delete
        public ActionResult Delete(int id)
        {
            Medico medico = AdminMedico.GetMedico(id);
            if (medico == null)
           {
                return HttpNotFound();
            }
            return View("Delete", medico);

        }

        // POST: Medico/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var medico = AdminMedico.GetMedico(id);
            AdminMedico.Delete(medico);
            return RedirectToAction("Index");

        }
    }
}