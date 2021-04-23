using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTransportes.Models
{
    public class Chofer
    {
        [Required]
        public int ChoferId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string DNI { get; set; }
        [RegularExpression(".+\\@.+\\..+")]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [NotMapped]
        public Vehiculo Vehiculo { get; set; }
    }
}