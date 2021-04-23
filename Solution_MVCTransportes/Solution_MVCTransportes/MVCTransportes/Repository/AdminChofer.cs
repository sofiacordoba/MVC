using MVCTransportes.Data;
using MVCTransportes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTransportes.Repository
{
    public static class AdminChofer
    {
        //declarar e instanciar a EntityFramework
        private static MyDbContext context = new MyDbContext();

        public static List<Chofer> ListarChoferes()
        {
            //usamos EF para traer la coleccion de Clientes
            List<Chofer> choferes = context.Choferes.ToList();
            //Enviamos a la vista Index la lista de Clientes
            return choferes;
        }
        public static void CargarChofer(Chofer chofer)
        {
            //guardamos en memoria
            context.Choferes.Add(chofer);
            //guardamos en la base de datos
            context.SaveChanges();
            //vamos a la accion index
        }
        public static Chofer TraerChofer(int id)
        {
            return context.Choferes.Find(id);
        }
        public static void EliminarChofer(Chofer chofer)
        {
            context.Choferes.Remove(chofer);
            context.SaveChanges();
        }

        public static void Actualizar(Chofer choferDB, Chofer choferActualizado)
        {
            //actualizamos las propiedades
            
            choferDB.Apellido = choferActualizado.Apellido;
            choferDB.DNI = choferActualizado.DNI;
            choferDB.Nombre = choferActualizado.Nombre;
            choferDB.Celular = choferActualizado.Celular;
            choferDB.Ciudad = choferActualizado.Ciudad;
            choferDB.Email = choferActualizado.Email;

            //guardamos en la base de datos
            context.SaveChanges();
            //vamos a la accion index
        }
        public static Vehiculo TraerVehiculo(int choferID)
        {
            return AdminVehiculo.TraerVehiculoDeChofer(choferID);
        }
    }
}