﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTransportes.Models
{
    public class Chofer
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public int Dni { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required]
        public string NroRegistro { get; set; }

        [Required]
        public string Ciudad { get; set; }

    }
}