using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public sealed class Country : Base
    {
        [Required]
        [MaxLength(General.TEXT_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}