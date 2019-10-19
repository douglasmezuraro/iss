using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("States")]
    [DisplayName("Estado")]
    public class State : Base
    {
        [Required]
        [MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [MinLength(General.UF_LENGTH), MaxLength(General.UF_LENGTH)]
        [DisplayName("UF")]
        public string UF { get; set; }
    }
}