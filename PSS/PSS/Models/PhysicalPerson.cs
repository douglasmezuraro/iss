using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class PhysicalPerson : Person
    {
        [Required]
        [MinLength(DescriptionMinLength), MaxLength(DescriptionMaxLength)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength), MaxLength(DescriptionMaxLength)]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [MinLength(14), MaxLength(14)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.###.###-##}")]
        public string CPF { get; set; }

        [Required]
        [DisplayName("Nascimento")]
        public DateTime? Birth { get; set; }

        [Required]
        [DisplayName("Gênero")]
        public int? GenderId { get; set; }

        [DisplayName("Gênero")]
        public Gender Gender { get; set; }
    }
}