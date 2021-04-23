using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;  //agregar


namespace OperasWebSite.Models
{
    public class CheckValidYear : ValidationAttribute
    {
        public CheckValidYear()  //contructor
        {
            ErrorMessage = "La ópera más antigua es Daphne, 1598, de Corsi Peri y Rinuccini";
        }

        public override bool IsValid(object value)
        {
            int year = (int)value;
            if (year < 1598)
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