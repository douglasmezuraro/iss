using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("SaleOrders")]
    [DisplayName("Pedido de venda")]
    public sealed class SaleOrder : Order
    {
        public override Freight Freight { get; set; } = new SaleOrderFreight();

        public override Payment Payment { get; set; } = new SaleOrderPayment();

        public override void FinalizeOrder()
        {
            base.FinalizeOrder();

            foreach (var item in Items)
            {
                item.Product.Stock -= item.Quantity;
            }
        }

        public override void ReturnOrder()
        {
            base.ReturnOrder();

            foreach (var item in Items)
            {
                item.Product.Stock += item.Quantity;
            }
        }
    }
}