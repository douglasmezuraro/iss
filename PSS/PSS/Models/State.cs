using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("States")]
    [DisplayName("Estado")]
    public class State : Base
    {
        private const int UFLength = 2;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [MinLength(UFLength), MaxLength(UFLength)]
        [DisplayName("UF")]
        public string UF { get; set; }
    }
}