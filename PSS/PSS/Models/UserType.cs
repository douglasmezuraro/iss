using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum UserType
    {
        [Display(Name = "Indefinido")]
        Undefined,

        [Display(Name = "Administrador")]
        Admin,

        [Display(Name = "Cliente")]
        Client,

        [Display(Name = "Visitante")]
        Visitor
    }
}