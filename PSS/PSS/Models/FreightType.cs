using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum FreightType
    {
        [Display(Name = "Indefinido")]
        Undefined,

        [Display(Name = "Correios")]
        PostOffice,

        [Display(Name = "Transportadora")]
        ShippingCompany
    }
}