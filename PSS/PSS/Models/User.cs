using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Users")]
    [DisplayName("Usuário")]
    public sealed class User : PhysicalPerson
    {
        [Required]
        [MaxLength(General.PASSWORD_LENGTH)]
        [PasswordPropertyText(true)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Tipo de usuário")]
        public UserType UserType { get; set; }

        [NotMapped]
        [DisplayName("Carrinho")]
        public Cart Cart { get; set; } = new Cart();
    }
}