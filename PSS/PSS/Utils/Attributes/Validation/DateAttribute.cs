using System;
using System.ComponentModel.DataAnnotations;

namespace PSS.Utils.Attributes.Validation
{
    public enum Temporality { Past, Now, Future };

    public class DateAttribute : ValidationAttribute
    {
        public Temporality Temporality { get; set; }

        public DateAttribute(Temporality temporality)
        {
            Temporality = temporality;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Validate(value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage(value));
        }

        private bool Validate(object value)
        {
            if (value == null)
            {
                return true;
            }

            switch (Temporality)
            {
                case Temporality.Past   : return ((DateTime)value).Date < DateTime.Now.Date;
                case Temporality.Now    : return ((DateTime)value).Date == DateTime.Now.Date;
                case Temporality.Future : return ((DateTime)value).Date > DateTime.Now.Date;
            }

            throw new ArgumentException();
        }

        private string GetErrorMessage(object value)
        {
            switch (Temporality)
            {
                case Temporality.Past   : return "A data deve ser anterior a data atual";
                case Temporality.Now    : return "A data deve ser igual a data atual";
                case Temporality.Future : return "A data deve ser posterior a data atual";
            }

            throw new ArgumentException();
        }
    }
}