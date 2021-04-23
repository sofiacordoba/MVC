using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTransportes.Models
{
    public class Vehiculo
    {
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string ChoferAsignado { get; set; }

        [Required]
        public int Matricula { get; set; }

        [Required]
        public string Caracteristicas { get; set; }
    }
}