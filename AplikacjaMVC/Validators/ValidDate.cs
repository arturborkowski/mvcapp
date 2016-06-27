using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AplikacjaMVC.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidDate : ValidationAttribute
    {         

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime productionDate = Convert.ToDateTime(value);
            if (productionDate > DateTime.Now)
            {
                return new ValidationResult("Production date can not be greater than current date.");
            }

            return ValidationResult.Success;
        }

    }
}