using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Categories")]
    [DisplayName("Categoria")]
    public sealed class Category : Base
    {
        [Required]
        [MinLength(General.DESCRIPTION_MIN_LENGTH), MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Perecível?")]
        public bool IsPerishable { get; set; }
    }
}