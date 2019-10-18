using System;
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
        [MinLength(DescriptionMinLength), MaxLength(DescriptionMaxLength)]
        [DisplayName("Descrição")]
        public String Description { get; set; }
    }
}