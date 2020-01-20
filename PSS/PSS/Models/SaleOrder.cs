using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
                if ((item.Product.Stocks == null) || (item.Product.Stocks.Count == 0))
                {
                    item.Product.Stocks = new List<Stock> { new Stock { Quantity = - item.Quantity, Out = item.Quantity, Date = System.DateTime.Now } };
                    return;
                }

                item.Product.Stocks.Add(
                    new Stock
                    {
                        Quantity = item.Product.Stocks.OrderBy(s => s.Id).LastOrDefault().Quantity - item.Quantity,
                        Out = item.Quantity,
                        Date = System.DateTime.Now
                    });
            }
        }

        public override void ReturnOrder()
        {
            base.ReturnOrder();

            foreach (var item in Items)
            {
                item.Product.Stocks.Add(
                    new Stock
                    {
                        Quantity = item.Product.Stocks.OrderBy(s => s.Id).LastOrDefault().Quantity + item.Quantity,
                        In = item.Quantity,
                        Date = System.DateTime.Now
                    });
            }
        }
    }
}