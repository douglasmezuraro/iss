using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Genders")]
    [DisplayName("Gênero")]
    public class Gender : Base
    {
        [Required]
        [MinLength(DescriptionMinLength), MaxLength(DescriptionMaxLength)]
        [DisplayName("Descrição")]
        public string Description { get; set; }
    }
}