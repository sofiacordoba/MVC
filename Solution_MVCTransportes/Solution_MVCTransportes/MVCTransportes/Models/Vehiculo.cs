using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTransportes.Models
{
    public class Vehiculo
    {
        [Required]
        [Key]
        public string Matricula { get; set; }
        [CheckValidModel]
        public string Modelo { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public int ChoferID { get; set; }
        [Required]
        public string Caracteristicas { get; set; }
        [NotMapped]
        public Chofer Chofer { get; set; }
    }
}