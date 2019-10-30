using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PSS.Utils.Attributes.Validation
{
    public class PhoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string phone = (string)value;
            Regex regex = new Regex(@"^\([0-9]{2}\)\s[0-9]{4,5}\-[0-9]{4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if ((value == null) || regex.IsMatch(phone))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage(phone));
        }

        private string GetErrorMessage(string value)
        {
            return "O valor '" + value + "' não é um telefone válido. O telefone deve ter os seguintes formatos: '(00) 00000-0000' ou '(00) 0000-0000'";
        }
    }
}