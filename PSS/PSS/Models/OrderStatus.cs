using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("OrderStatuses")]
    [DisplayName("Status do pedido")]
    public class OrderStatus : Base
    {
        [Required]
        [MinLength(General.DESCRIPTION_MIN_LENGTH), MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Descrição")]
        public string Description { get; set; }
    }
}