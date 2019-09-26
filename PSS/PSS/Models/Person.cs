using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class Person : Base
    {
        [Required]
        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Endereço")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Número")]
        public int Number { get; set; }

        [Required]
        [DisplayName("CEP")]
        public string PostalCode { get; set; }

        [DisplayName("Complemento")]
        public string Complement { get; set; }

        [DisplayName("Referência")]
        public string Reference { get; set; }

        [Required]
        [DisplayName("Cidade")]
        public int? CityId { get; set; }

        [DisplayName("Cidade")]
        public City City { get; set; }
    }
}