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
        [DisplayName("Valor")]
        public double Value { get; set; }

        [Required]
        [DisplayName("Tipo de pagamento")]
        public int PaymentTypeId { get; set; }

        [DisplayName("Tipo de pagamento")]
        public PaymentType PaymentType { get; set; }
    }
}