using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("SaleOrders")]
    [DisplayName("Pedido de venda")]
    public sealed class SaleOrder : Order
    {
        public SaleOrder(User user) : base(user)
        {

        }

        public override Freight Freight { get; set; } = new SaleOrderFreight();

        public override void FinalizeOrder(User user)
        {
            base.FinalizeOrder(user);

            foreach (var item in Items)
            {
                item.Product.Stock -= item.Quantity;
            }
        }

        public override void ReturnOrder()
        {
            throw new System.NotImplementedException("A devolução do pedido de venda ainda não foi implementado!");
        }
    }
}