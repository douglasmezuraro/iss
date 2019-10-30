using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("States")]
    [DisplayName("Estado")]
    public sealed class State : Base
    {
        [Required]
        [MaxLength(General.TEXT_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(General.ABREVIATION_LENGTH)]
        [DisplayName("UF")]
        public string UF { get; set; }

        [Required]
        [DisplayName("País")]
        public int CountryId { get; set; }

        [DisplayName("País")]
        public Country Country { get; set; }
    }
}