using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperasWebSite.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }


        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }  // sirve para guardar las credenciales mientras la cookie se mantenga
    }
}