using PSS.Utils.Constants;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PSS.Utils;

namespace PSS.Models
{
    [DisplayName("Pedido")]
    public abstract class Order : Base
    {
        public Order()
        {
            UserId = Global.User.Id;

            foreach (var Item in Global.User.Cart.Items)
            {
                Items.Add(Item);
            }

            Freight.Address = Global.User.Address;
            Freight.CityId = Global.User.CityId;
            Freight.Complement = Global.User.Complement;
            Freight.Number = Global.User.Number;
            Freight.PostalCode = Global.User.PostalCode;
            Freight.Reference = Global.User.Reference;
            Freight.Price = 100;
        }

        [DisplayName("Preço total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double TotalPrice => Items.Count == 0 ? 0 : Items.Sum(i => i.Price) + Freight.Price;

        [DisplayName("Data")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [Required]
        [DisplayName("Status")]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.InProgress;

        [Required]
        [DisplayName("Usuário")]
        public int UserId { get; set; }

        [DisplayName("Usuário")]
        public User User { get; set; }
       
        [Required]
        [DisplayName("Frete")]
        public int FreightId { get; set; }

        [DisplayName("Frete")]
        public abstract Freight Freight { get; set; }

        [Required]
        [DisplayName("Pagamento")]
        public int PaymentId { get; set; }

        [DisplayName("Pagamento")]
        public abstract Payment Payment { get; set; }

        [DisplayName("Carrinho")]
        public ICollection<Item> Items { get; set; } = new List<Item>();

        public virtual void FinalizeOrder()
        { 
            Date = System.DateTime.Now;
            OrderStatus = OrderStatus.Finished;
            Global.User.Cart.Items.Clear();
        }

        public virtual void CancelOrder()
        {
            OrderStatus = OrderStatus.Canceled;
        }

        public abstract void ReturnOrder();
    }
}