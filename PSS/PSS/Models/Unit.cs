using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Units")]
    [DisplayName("Unidades")]
    public sealed class Unit : Base
    {
        [Required]
        [MaxLength(General.TEXT_LENGTH)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required]
        [StringLength(General.ABREVIATION_LENGTH)]
        [DisplayName("Abreviação")]
        public string Abbreviation { get; set; }
    }
}