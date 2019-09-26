using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class LegalPerson : Person
    {
        [Required]
        [DisplayName("Nome resumido")]
        public string ShortName { get; set; }

        [Required]
        [DisplayName("Nome completo")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("CNPJ")]
        [MinLength(18), MaxLength(18)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:##.###.###/####-##}")]
        public string CNPJ { get; set; }
    }
}