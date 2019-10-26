using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Cities")]
    [DisplayName("Cidade")]
    public sealed class City : Base
    {
        [Required]
        [MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Estado")]
        public int StateId { get; set; }

        [DisplayName("Estado")]
        public State State { get; set; }
    }
}