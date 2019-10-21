using System.ComponentModel;
using System.Linq;

namespace PSS.Models
{
    [DisplayName("Pedido de venda")]
    public class SaleOrder : Order
    {
        [DisplayName("Valor total")]
        public override double TotalValue => Items.Sum(i => i.TotalSalePrice) + Installments.Sum(i => i.Value);       

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