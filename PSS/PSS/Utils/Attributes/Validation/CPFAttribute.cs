using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PSS.Utils.Attributes.Validation
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = false)]
    public class CPFAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (string)value;
            Regex regex = new Regex(@"([0-9]{3}\.){2}[0-9]{3}\-[0-9]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if ((value == null) || regex.IsMatch(cpf))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage());
        }

        public string FormatErrorMessage()
        {
            return "O CPF deve ter o seguinte formato: '000.000.000-00'";
        }
    }
}