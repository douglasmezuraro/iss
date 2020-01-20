using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    [DisplayName("Pagamento - Cartão")]
    public abstract class Payment : Base
    {
        [Required]
        [MaxLength(General.TEXT_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [CreditCard]
        [DataType(DataType.CreditCard)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [DisplayName("Número")]
        public string Number { get; set; }

        [Required]
        [DisplayName("Mês de vencimento")]
        public Month Month { get; set; }

        [Required]
        [Range(2019, 2030)]
        [DisplayName("Ano de vencimento")]
        public short Year { get; set; }
    }

    public sealed class PurchaseOrderPayment : Payment
    {
    }

    public sealed class SaleOrderPayment : Payment
    {
    }
}