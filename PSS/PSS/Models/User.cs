using PSS.Utils.Constants;
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
        [MinLength(General.PASSWORD_MIN_LENGTH), MaxLength(General.PASSWORD_MAX_LENGTH)]
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