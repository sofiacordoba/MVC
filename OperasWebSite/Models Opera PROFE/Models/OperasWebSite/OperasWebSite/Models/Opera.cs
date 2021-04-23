using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;//agregar
namespace OperasWebSite.Models
{
    public class Opera
    {
        public int OperaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(200)]
        public string Title { get; set; }

        [CheckValidYearValidation]
        public int Year { get; set; }

        [Required]
        public string Composer { get; set; }
    }
}