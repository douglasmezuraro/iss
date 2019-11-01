using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("PurchaseOrders")]
    [DisplayName("Pedido de compra")]
    public sealed class PurchaseOrder : Order
    {
        public PurchaseOrder()
        {

        }

        public PurchaseOrder(User user) : base(user)
        {

        }

        public override Freight Freight { get; set; } = new PurchaseOrderFreight();

        public override void FinalizeOrder(User user)
        {
            base.FinalizeOrder(user);

            foreach(var item in Items)
            {
                item.Product.Stock += item.Quantity;
            }            
        }

        public override void ReturnOrder()
        {
            throw new System.NotImplementedException("A devolução do pedido de compra ainda não foi implementado!");
        }
    }
}