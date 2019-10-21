using System.ComponentModel;

namespace PSS.Models
{
    [DisplayName("Pedido de compra")]
    public class PurchaseOrder : Order
    {
        public override void FinalizeOrder()
        {
            base.FinalizeOrder();

            foreach(var item in Items)
            {
                item.Product.Stock += item.Quantity;
            }            
        }
    }
}