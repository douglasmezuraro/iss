using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum PaymentType
    {
        [Display(Description = "Indefinido")]
        Undefined,

        [Display(Description = "Dinheiro")]
        Money,

        [Display(Description = "Cheque")]
        Check,

        [Display(Description = "Cartão de Crédito")]
        CreditCard,

        [Display(Description = "Cartão de Débito")]
        DebitCard
    }
}