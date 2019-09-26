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
        public const int Admin = 1;
        public const int Client = 2;
        public const int Visitor = 3;

        [Required]
        [MinLength(DescriptionMinLength), MaxLength(DescriptionMaxLength)]
        [DisplayName("Descrição")]
        public String Description { get; set; }
    }
}