using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum PaymentType
    {
        [Display(Name = "Indefinido")]
        Undefined,

        [Display(Name = "Dinheiro")]
        Money,

        [Display(Name = "Cheque")]
        Check,

        [Display(Name = "Cartão de Crédito")]
        CreditCard,

        [Display(Name = "Cartão de Débito")]
        DebitCard
    }
}