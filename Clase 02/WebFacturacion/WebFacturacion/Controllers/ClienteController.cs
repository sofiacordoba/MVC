using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFacturacion.Data;
using WebFacturacion.Models;

namespace WebFacturacion.Controllers
{
    public class ClienteController : Controller
    {

        //declarar e instanciar a EntityFramework
        private WebFacturacionDBContext context = new WebFacturacionDBContext();

        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> clientes = context.Clientes.ToList();

            return View("Index", clientes);
        }


        //GET: Cliente/Create
        [HttpGet]
        public ActionResult Create()
        {
            Cliente cliente = new Cliente();
            return View(cliente);
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

        public ActionResult Detail(int id)
        {
            Cliente cliente = context.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();

            }
            return View("Display", cliente);
        }


        public ActionResult GetCliente(int id)
        {
            Cliente cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                return View("Display", cliente);
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
            Cliente cliente = context.Clientes.Find(id);

            return View(cliente);
        }



        //POST: Clientes/Create
        [HttpPost]
        public ActionResult Edit(Cliente Cliente)
        {
            //validar las propiedades del modelo
            if (ModelState.IsValid)
            {
                //buscamos en memoria
                Cliente cliente = context.Clientes.Find(Cliente.Id);
                //actualizamos las propiedades
                cliente.Apellido = Cliente.Apellido;
                cliente.Cuit = Cliente.Cuit;
                cliente.Dni = Cliente.Dni;
                cliente.FechaNacimiento = Cliente.FechaNacimiento;
                cliente.Nombre = Cliente.Nombre;

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
            Cliente cliente = context.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View("Delete", cliente);

        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = context.Clientes.Find(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}