using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum Gender
    {
        [Display(Name = "Indefinido")]
        Undefined,

        [Display(Name = "Mulher")]
        Female,

        [Display(Name = "Homem")]
        Male
    }
}