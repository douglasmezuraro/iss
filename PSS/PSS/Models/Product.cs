using PSS.Utils;
using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Products")]
    [DisplayName("Produto")]
    public sealed class Product : Base
    {
        [Required]
        [MaxLength(General.TEXT_LENGTH)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Preço de compra")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double PurchasePrice { get; set; }

        [Required]
        [DisplayName("Preço de venda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double SalePrice { get; set; }

        [Required]
        [DisplayName("Estoque")]
        public int Stock { get; set; }

        [Required]
        [DisplayName("Peso (KG)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double Weight { get; set; }

        [DisplayName("Validade")]
        [DataType(DataType.Date)]
        public System.DateTime? Expiration { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

        [DisplayName("Categoria")]
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

        [NotMapped]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        [DisplayName("Preço unitário")]
        public double Price => Global.User.UserType == UserType.Admin ? PurchasePrice : SalePrice;
    }
}