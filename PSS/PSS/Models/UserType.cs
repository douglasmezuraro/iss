using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("UserTypes")]
    [DisplayName("Tipo de usuário")]    
    public class UserType : Base 
    {
        public enum UserTypeEnum { Admin = 1, Client, Visitor };

        [Required]
        [MinLength(General.DESCRIPTION_MIN_LENGTH), MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Descrição")]
        public string Description { get; set; }
    }
}