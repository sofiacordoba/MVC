using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTransportes.Models
{
    public class CheckValidModel:ValidationAttribute
    {
        public CheckValidModel()
        {
            ErrorMessage = "el valor ingresado debe ser mayor a 2015.";
        }
        public override bool IsValid(object value)
        {
            int model = Convert.ToInt32(value);
            if (model <= 2015)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}