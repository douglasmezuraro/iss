using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PSS.Utils.Attributes.Validation
{
    public class CNPJAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cnpj = (string)value;
            Regex regex = new Regex(@"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if ((value == null) || regex.IsMatch(cnpj))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(cnpj));
        }

        public override string FormatErrorMessage(string name)
        {
            return "O valor '" + name + "' não é um CNPJ válido. O CPNJ deve ter o seguinte formato: '00.000.000/0000-00'";
        }
    }
}