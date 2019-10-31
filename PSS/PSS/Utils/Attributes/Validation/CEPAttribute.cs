using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PSS.Utils.Attributes.Validation
{
    public class CEPAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cep = (string)value;
            Regex regex = new Regex(@"^[0-9]{5}\-[0-9]{3}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if ((value == null) || regex.IsMatch(cep))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(cep));
        }

        public string FormatErrorMessage()
        {
            return "O CEP deve ter o seguinte formato: '00000-000'";
        }
    }
}