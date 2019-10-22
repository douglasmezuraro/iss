using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Installments")]
    [DisplayName("Parcela")]
    public class Installment : Base
    {
        [Required]
        [DisplayName("Preço")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Tipo de pagamento")]
        public int PaymentTypeId { get; set; }

        [DisplayName("Tipo de pagamento")]
        public PaymentType PaymentType { get; set; }
    }
}