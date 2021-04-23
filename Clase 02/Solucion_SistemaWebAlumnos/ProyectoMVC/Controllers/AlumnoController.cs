using ProyectoMVC.Datos;
using ProyectoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        //declarar e instanciar a EntityFramework
        private AlumnosDBContext context = new AlumnosDBContext();
        // GET: Alumno
        public ActionResult Index()
        {
            //usamos EF para traer la coleccion de alumnos
            List<Alumno> alumnos = context.Alumnos.ToList();
            //Enviamos a la vista Index la lista de alumnos
            return View("Index", alumnos);
        }
        //GET: Alumnos/Create
        [HttpGet]
        public ActionResult Create()
        {
            Alumno alumno = new Alumno();
            return View(alumno);
        }
        //POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                //guardamos en memoria
                context.Alumnos.Add(alumno);
                //guardamos en la base de datos
                context.SaveChanges();
                //vamos a la accion index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", alumno);
            }
        }
        public ActionResult Delete(int id)
        {
            Alumno alumno = context.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View("Delete", alumno);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno photo = context.Alumnos.Find(id);
            context.Alumnos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            Alumno alumno = context.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View("Display", alumno);
        }
        public ActionResult GetAlumno(int id)
        {
            Alumno alumno = context.Alumnos.Find(id);
            if (alumno != null)
            {
                return View("Display", alumno);
            }
            else
            {
                return null;
            }

        }
    }
}