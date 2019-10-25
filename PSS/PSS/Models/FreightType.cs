using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum FreightType
    {
        [Display(Name = "Indefinido")]
        Undefined,

        [Display(Name = "Correios")]
        Correios,

        [Display(Name = "Transportadora")]
        Transportadora
    }
}