using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperasWebSite.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        [StringLength(10,ErrorMessage = "máximo 10 caracteres", MinimumLength = 6)] // personalizo el mensaje
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")] //compara que esto sea igual a la prop Password
        public string ConfirmPassword { get; set; }
    }
}