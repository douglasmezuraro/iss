using PSS.Utils.Attributes.Validation;
using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class LegalPerson : Person
    {
        [Required]
        [DisplayName("Nome resumido")]
        [MaxLength(General.TEXT_LENGTH)]
        public string ShortName { get; set; }

        [Required]
        [DisplayName("Nome completo")]
        [MaxLength(General.TEXT_LENGTH)]
        public string FullName { get; set; }

        [Required]
        [CNPJ]
        [DisplayName("CNPJ")]
        [StringLength(General.CNPJ_LENGTH)]
        public string CNPJ { get; set; }
    }
}