using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PSS.Utils.Attributes.Validation
{
    public class CPFAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (string)value;
            Regex regex = new Regex("([0-9]{3}.){2}[0-9]{3}-[0-9]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if ((value == null) || regex.IsMatch(cpf))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage(cpf));
        }

        private string GetErrorMessage(string value)
        {
            return "O valor '" + value + "' não é um CPF válido. O CPF deve ter o seguinte formato: '000.000.000-00'";
        }
    }
}