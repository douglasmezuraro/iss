using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class LegalPerson : Person
    {
        [Required]
        [DisplayName("Nome resumido")]
        [MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        public string ShortName { get; set; }

        [Required]
        [DisplayName("Nome completo")]
        [MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        public string FullName { get; set; }

        [Required]
        [DisplayName("CNPJ")]
        [MinLength(General.CNPJ_LENTH), MaxLength(General.CNPJ_LENTH)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.CNPJ_MASK)]
        public string CNPJ { get; set; }
    }
}