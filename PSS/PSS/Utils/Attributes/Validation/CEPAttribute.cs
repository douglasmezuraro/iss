using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PSS.Utils.Attributes.Validation
{
    public class CEPAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (string)value;
            Regex regex = new Regex("[0-9]{5}-[0-9]{3}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if ((value == null) || regex.IsMatch(cpf))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage(cpf));
        }

        private string GetErrorMessage(string cpf)
        {
            return "O valor '" + cpf + "' não é um CEP válido.";
        }
    }
}