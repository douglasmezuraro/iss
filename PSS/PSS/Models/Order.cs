using PSS.Utils;
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

        [DisplayName("Valor total")]
        public abstract double TotalValue { get; }

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
        public ICollection<Freight> Freights { get; } = new List<Freight>();

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