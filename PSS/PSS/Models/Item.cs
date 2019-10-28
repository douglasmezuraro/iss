using PSS.Utils.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [DisplayName("Items")]
    public class Item : Base
    {
        [Required]
        [DisplayName("Quantidade")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Preço")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double Price => Product == null ? 0 : Product.Price * Quantity;

        [Required]
        [DisplayName("Produto")]
        public int ProductId { get; set; }

        [DisplayName("Produto")]
        public Product Product { get; set; }

        public int? PurchaseOrderId { get; set; }

        public int? SaleOrderId { get; set; }
    }
}