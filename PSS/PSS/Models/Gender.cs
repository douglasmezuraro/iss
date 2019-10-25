using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum Gender
    {
        [Display(Description = "Indefinido")]
        Undefined,

        [Display(Description = "Mulher")]
        Female,

        [Display(Description = "Homem")]
        Male
    }
}