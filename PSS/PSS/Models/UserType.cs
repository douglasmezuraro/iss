using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum UserType
    {
        [Display(Description = "Indefinido")]
        Undefined,

        [Display(Description = "Administrador")]
        Admin,

        [Display(Description = "Cliente")]
        Client,

        [Display(Description = "Visitante")]
        Visitor
    }
}