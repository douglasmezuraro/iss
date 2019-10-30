using PSS.Utils.Attributes.Validation;
using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class Person : Base
    {
        [Required]
        [Phone]
        [DisplayName("Telefone")]
        [MaxLength(General.TEXT_LENGTH)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("E-mail")]
        [MaxLength(General.TEXT_LENGTH)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Endereço")]
        [MaxLength(General.TEXT_LENGTH)]
        public string Address { get; set; }

        [Required]
        [DisplayName("Número")]
        public int Number { get; set; }

        [Required]
        [CEP]
        [StringLength(General.CEP_LENGTH)]
        [DisplayName("CEP")]
        public string PostalCode { get; set; }

        [DisplayName("Complemento")]
        [MaxLength(General.TEXT_LENGTH)]
        public string Complement { get; set; }

        [DisplayName("Referência")]
        [MaxLength(General.TEXT_LENGTH)]
        public string Reference { get; set; }

        [Required]
        [DisplayName("Cidade")]
        public int CityId { get; set; }

        [DisplayName("Cidade")]
        public City City { get; set; }
    }
}