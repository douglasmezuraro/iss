using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("PurchaseOrders")]
    [DisplayName("Pedido de compra")]
    public class PurchaseOrder : Order
    {
     //   [DisplayName("Frete")]
   //     public int FreightId { get; set; }

        [DisplayName("Frete")]
        public PurchaseOrderFreight Freight { get; set; } = new PurchaseOrderFreight();

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