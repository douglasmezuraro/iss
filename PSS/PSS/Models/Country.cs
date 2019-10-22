using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public class Country : Base
    {
        [Required]
        [MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}