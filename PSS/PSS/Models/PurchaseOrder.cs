using System.ComponentModel;
using System.Linq;

namespace PSS.Models
{
    [DisplayName("Pedido de compra")]
    public class PurchaseOrder : Order
    {
        [DisplayName("Valor total")]
        public override double TotalValue
        {
            get { return Items.Sum(item => item.TotalPurchasePrice) + Installments.Sum(installment => installment.Value); }
        }

        public override void FinalizeOrder()
        {
            foreach(var item in Items)
            {
                item.Product.Stock -= item.Quantity;
            }            
        }
    }
}