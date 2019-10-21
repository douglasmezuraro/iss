using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    [DisplayName("Items")]
    public class Item : Base
    {
        [Required]
        [DisplayName("Quantidade")]
        public double Quantity { get; set; }

        [Required]
        [DisplayName("Produto")]
        public int ProductId { get; set; }

        [DisplayName("Produto")]
        public Product Product { get; set; }

        [DisplayName("Preço total de venda")]
        public double TotalSalePrice => Product == null ? 0 : Quantity * Product.SalePrice;

        [DisplayName("Preço total de compra")]
        public double TotalPurchasePrice => Product == null ? 0 : Quantity * Product.PurchasePrice;
    }
}