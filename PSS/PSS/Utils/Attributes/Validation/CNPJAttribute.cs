﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PSS.Utils.Attributes.Validation
{
    public class CNPJAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cnpj = (string)value;
            Regex regex = new Regex("^[0-9]{2}.[0-9]{3}.[0-9]{3}/[0-9]{4}-[0-9]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if ((value == null) || regex.IsMatch(cnpj))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage(cnpj));
        }

        private string GetErrorMessage(string value)
        {
            return "O valor '" + value + "' não é um CNPJ válido.";
        }
    }
}