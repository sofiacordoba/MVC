using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFacturacion.Models
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public int Dni { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int Cuit { get; set; }
    }
}