using SistemaWebClinica.Data;
using SistemaWebClinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWebClinica.Repositories
{
    public static class AdminMedico
    {
        private static MedicoDBContext context = new MedicoDBContext();

        public static List<Medico> GetMedicos()
        {
            List<Medico> medicos = context.Medicos.ToList();
            return medicos;
        }


        public static Medico GetMedico(int id)
        {
            return context.Medicos.Find(id);
        }

        public static List<Medico> GetMedicosEsp(string  especialidad)
        {
            return context.Medicos.Where(x => x.Especialidad == especialidad).ToList();
        }

        public static List<Medico> GetMedicosEspyCiudad(string ciudad, string especialidad)
        {
          return context.Medicos.Where(m => m.Ciudad == ciudad && m.Especialidad == especialidad).ToList();
        }


        public static int Create(Medico medico)
        {
            context.Medicos.Add(medico);
            int result = context.SaveChanges();

            return result;
        }


        public static void Delete(Medico medico)
        {
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }

    }
}