using PSS.Utils;
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
            OrderStatus = OrderStatus.InProgress;

            foreach (var Item in Global.Cart.Items)
            {
                Items.Add(Item);
            }
        }

        [DisplayName("Preço total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double TotalPrice => Items.Count == 0 ? 0 : Items.Sum(i => i.Product.Price) + Installments.Sum(i => i.Price);

        [DisplayName("Data")]
        public System.DateTime? Date { get; set; }

        [Required]
        [DisplayName("Status")]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        [DisplayName("Usuário")]
        public int UserId { get; set; }

        [DisplayName("Usuário")]
        public User User { get; set; }

        [DisplayName("Carrinho")]
        public ICollection<Item> Items { get; } = new List<Item>();

        [DisplayName("Pagamento")]
        public ICollection<Installment> Installments { get; } = new List<Installment>();

        public virtual void FinalizeOrder()
        {
            UserId = Global.User.Id;
            Date = System.DateTime.Now.Date;
            OrderStatus = OrderStatus.Finished;
            Global.Cart.Items.Clear();
        }
    }
}