using System.ComponentModel;
using System.Linq;

namespace PSS.Models
{
    [DisplayName("Pedido de venda")]
    public class SaleOrder : Order
    {
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