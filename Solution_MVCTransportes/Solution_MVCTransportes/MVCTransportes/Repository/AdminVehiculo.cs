using MVCTransportes.Data;
using MVCTransportes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MVCTransportes.Repository
{
    public static class AdminVehiculo
    {
        private static MyDbContext context = new MyDbContext();

        internal static Vehiculo TraerVehiculoDeChofer(int choferID)
        {
            return context.Vehiculos.SingleOrDefault(x=>x.Chofer.ChoferId == choferID);

        }

        internal static List<Vehiculo> ListarVehiculos()
        {
            List<Vehiculo> vehiculos = context.Vehiculos.ToList();
            foreach (var vehiculo in vehiculos)
            {
                vehiculo.Chofer = AdminChofer.TraerChofer(vehiculo.ChoferID);
            }
            return vehiculos;
        }

        internal static void CargarVehiculo(Vehiculo vehiculo)
        {
            //guardamos en memoria
            context.Vehiculos.Add(vehiculo);
            //guardamos en la base de datos
            context.SaveChanges();
            //vamos a la accion index

        }

        internal static Vehiculo TraerVehiculo(string id)
        {
            return context.Vehiculos.SingleOrDefault(x=>x.Matricula == id);
        }

        internal static void EliminarVehiculo(Vehiculo vehiculo)
        {
            context.Vehiculos.Remove(vehiculo);
            context.SaveChanges();
        }

        internal static void Actualizar(Vehiculo vehiculoDB, Vehiculo vehiculoActualizado)
        {
            //actualizamos las propiedades

            vehiculoDB.Caracteristicas = vehiculoActualizado.Caracteristicas;
            vehiculoDB.ChoferID = vehiculoActualizado.ChoferID;
            vehiculoDB.Marca = vehiculoActualizado.Marca;
            vehiculoDB.Modelo = vehiculoActualizado.Modelo;

            //guardamos en la base de datos
            context.SaveChanges();
            //vamos a la accion index
        }
    }
}