using System.ComponentModel;
using System.Linq;

namespace PSS.Models
{
    [DisplayName("Pedido de venda")]
    public class SaleOrder : Order
    {
        [DisplayName("Valor total")]
        public override double TotalValue
        {
            get { return Items.Sum(item => item.TotalSalePrice) + Installments.Sum(installment => installment.Value); }
        }
    }
}