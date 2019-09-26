using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Users")]
    [DisplayName("Usuário")]
    public class User : PhysicalPerson
    {
        [Required]
        [MinLength(8), MaxLength(16)]
        [PasswordPropertyText(true)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Tipo de usuário")]
        public int? UserTypeId { get; set; }

        [DisplayName("Tipo de usuário")]
        public UserType UserType { get; set; }
    }
}