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
            UserId = Global.User.Id;
            Date = System.DateTime.Now;
            OrderStatusId = (int)OrderStatus.Enum.InProgress;

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
        public int OrderStatusId { get; set; }

        [DisplayName("Status")]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        [DisplayName("Usuário")]
        public int UserId { get; set; }

        [DisplayName("Usuário")]
        public User User { get; set; }

        [DisplayName("Frete")]
        public Freight Freight { get; } = new Freight();

        [DisplayName("Carrinho")]
        public ICollection<Item> Items { get; } = new List<Item>();

        [DisplayName("Pagamento")]
        public ICollection<Installment> Installments { get; } = new List<Installment>();

        public virtual void FinalizeOrder()
        {
            OrderStatusId = (int)OrderStatus.Enum.Finished;
            Global.Cart.Items.Clear();
        }
    }
}