using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Products")]
    [DisplayName("Produto")]
    public class Product : Base
    {
        [Required]
        [MinLength(General.DESCRIPTION_MIN_LENGTH), MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Descrição resumida")]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(General.DESCRIPTION_MIN_LENGTH), MaxLength(General.DESCRIPTION_MAX_LENGTH)]
        [DisplayName("Descrição completa")]
        public string FullDescription { get; set; }

        [Required]
        [DisplayName("Preço de compra")]
        public double PurchasePrice { get; set; }

        [Required]
        [DisplayName("Preço de venda")]
        public double SalePrice { get; set; }

        [Required]
        [DisplayName("Estoque")]
        public double Stock { get; set; }

        [Required]
        [DisplayName("Peso (KG)")]
        public double Weight { get; set; }

        [DisplayName("Validade")]       
        public System.DateTime? Expiration { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

        [DisplayName("Caregoria")]
        public Category Category { get; set; }

        [Required]
        [DisplayName("Fabricante")]
        public int ManufacturerId { get; set; }

        [DisplayName("Fabricante")]
        public Manufacturer Manufacturer { get; set; }

        [Required]
        [DisplayName("Fornecedor")]
        public int ProviderId { get; set; }

        [DisplayName("Fornecedor")]
        public Provider Provider { get; set; }

        [Required]
        [DisplayName("Unidade")]
        public int UnitId { get; set; }

        [DisplayName("Unidade")]
        public Unit Unit { get; set; }
    }
}