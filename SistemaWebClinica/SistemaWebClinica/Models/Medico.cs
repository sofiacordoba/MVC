using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebClinica.Models
{
    public class Medico
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Matricula { get; set; }

        [Required]
        [StringLength(50)]
        public string Especialidad { get; set; }

        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }
    }
}