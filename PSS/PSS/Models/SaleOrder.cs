using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("SaleOrders")]
    [DisplayName("Pedido de venda")]
    public sealed class SaleOrder : Order
    {
        [Required]
        [DisplayName("Frete")]
        public int FreightId { get; set; }

        [DisplayName("Frete")]
        public SaleOrderFreight Freight { get; set; } = new SaleOrderFreight();

        public override void FinalizeOrder()
        {
            base.FinalizeOrder();

            foreach (var item in Items)
            {
                item.Product.Stock -= item.Quantity;
            }
        }
    }
}