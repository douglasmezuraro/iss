using PSS.Utils.Attributes.Validation;
using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class PhysicalPerson : Person
    {
        [Required]
        [MinLength(General.DESCRIPTION_MIN_LENGTH), MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [MinLength(General.DESCRIPTION_MIN_LENGTH), MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [CPF][DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.CPF_MASK)]
        public string CPF { get; set; }

        [Required]
        [DisplayName("Nascimento")]
        [DataType(DataType.Date)]
        public System.DateTime Birth { get; set; }

        [Required]
        [DisplayName("Gênero")]
        public Gender Gender { get; set; }
    }
}