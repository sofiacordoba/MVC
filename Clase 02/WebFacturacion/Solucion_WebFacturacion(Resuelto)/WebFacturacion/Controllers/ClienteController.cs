using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFacturacion.Datos;
using WebFacturacion.Models;

namespace WebFacturacion.Controllers
{
    public class ClienteController : Controller
    {
        //declarar e instanciar a EntityFramework
        private ClienteDbContext context = new ClienteDbContext();
        // GET: Cliente
        public ActionResult Index()
        {
            //usamos EF para traer la coleccion de Clientes
            List<Cliente> clientes = context.Clientes.ToList();
            //Enviamos a la vista Index la lista de Clientes
            return View("Index", clientes);
        }
        //GET: Clientes/Create
        [HttpGet]
        public ActionResult Create()
        {
            Cliente Cliente = new Cliente();
            return View(Cliente);
        }
        //POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente Cliente)
        {
            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                //guardamos en memoria
                context.Clientes.Add(Cliente);
                //guardamos en la base de datos
                context.SaveChanges();
                //vamos a la accion index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", Cliente);
            }
        }
        public ActionResult Details(int id)
        {
            Cliente Cliente = context.Clientes.Find(id);
            if (Cliente == null)
            {
                return HttpNotFound();
            }
            return View("Display", Cliente);
        }
        public ActionResult GetCliente(int id)
        {
            Cliente Cliente = context.Clientes.Find(id);
            if (Cliente != null)
            {
                return View("Display", Cliente);
            }
            else
            {
                return null;
            }

        }
        //GET: Clientes/Create
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cliente ClienteDB = context.Clientes.Find(id);

            return View(ClienteDB);
        }
        //POST: Clientes/Create
        [HttpPost]
        public ActionResult Edit(Cliente Cliente)
        {
            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                //buscamos en memoria
                Cliente ClienteDB = context.Clientes.Find(Cliente.Id);
                //actualizamos las propiedades
                ClienteDB.Apellido = Cliente.Apellido;
                ClienteDB.Cuit = Cliente.Cuit;
                ClienteDB.DNI = Cliente.DNI;
                ClienteDB.FechaNacimiento = Cliente.FechaNacimiento;
                ClienteDB.Nombre = Cliente.Nombre;
                
                //guardamos en la base de datos
                context.SaveChanges();
                //vamos a la accion index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", Cliente);
            }
        }
        public ActionResult Delete(int id)
        {
            Cliente Cliente = context.Clientes.Find(id);
            if (Cliente == null)
            {
                return HttpNotFound();
            }
            return View("Delete", Cliente);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente photo = context.Clientes.Find(id);
            context.Clientes.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}