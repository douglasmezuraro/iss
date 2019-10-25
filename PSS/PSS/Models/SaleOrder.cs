using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("SaleOrders")]
    [DisplayName("Pedido de venda")]
    public class SaleOrder : Order
    {
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