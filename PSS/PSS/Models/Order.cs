using PSS.Utils.Constants;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    [DisplayName("Pedido")]
    public abstract class Order : Base
    {
        public Order()
        {

        }

        public Order(User user)
        {
            User = user;

            foreach (var Item in User.Cart.Items)
            {
                Items.Add(Item);
            }

            Freight.Address = user.Address;
            Freight.City = user.City;
            Freight.CityId = user.CityId;
            Freight.Complement = user.Complement;
            Freight.Number = user.Number;
            Freight.PostalCode = user.PostalCode;
            Freight.Price = 100;
            Freight.Reference = user.Reference;
        }

        [DisplayName("Preço total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double TotalPrice => Items.Count == 0 ? 0 : Items.Sum(i => i.Price) + Installments.Sum(i => i.Price) + Freight.Price;

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

        [DisplayName("Carrinho")]
        public ICollection<Item> Items { get; set; } = new List<Item>();

        [DisplayName("Pagamento")]
        public ICollection<Installment> Installments { get; } = new List<Installment>();

        public virtual void FinalizeOrder(User user)
        { 
            Date = System.DateTime.Now;
            OrderStatus = OrderStatus.Finished;
            UserId = user.Id;
            user.Cart.Items.Clear();
        }

        public virtual void CancelOrder()
        {
            OrderStatus = OrderStatus.Canceled;
        }

        public abstract void ReturnOrder();
    }
}