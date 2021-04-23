using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace OperasWebSite.Models
{
    public class CheckValidYearValidation: ValidationAttribute
    {
        public CheckValidYearValidation() 
        {
            ErrorMessage = "El año debe ser mayor o igual 1598";
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