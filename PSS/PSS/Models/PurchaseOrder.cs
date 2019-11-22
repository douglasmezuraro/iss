using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("PurchaseOrders")]
    [DisplayName("Pedido de compra")]
    public sealed class PurchaseOrder : Order
    {
        public override Freight Freight { get; set; } = new PurchaseOrderFreight();

        public override Payment Payment { get; set; } = new PurchaseOrderPayment();

        public override void FinalizeOrder()
        {
            base.FinalizeOrder();

            foreach (var item in Items)
            {
                item.Product.Stock += item.Quantity;
            }            
        }

        public override void ReturnOrder()
        {
            base.ReturnOrder();

            foreach (var item in Items)
            {
                item.Product.Stock -= item.Quantity;
            }
        }
    }
}