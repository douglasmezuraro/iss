using PSS.Utils.Attributes.Validation;
using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    [DisplayName("Frete")]
    public abstract class Freight : Base
    {
        [Required]
        [DataType(DataType.Date)]
        [Date(Temporality.Future)]
        [DisplayName("Previsão de entrega")]
        public System.DateTime DeliveryDate { get; set; }

        [Required]
        [DisplayName("Preço")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Tipo de frete")]
        public FreightType FreightType { get; set; }

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

    public sealed class PurchaseOrderFreight : Freight
    {
    }

    public sealed class SaleOrderFreight : Freight
    {
    }
}