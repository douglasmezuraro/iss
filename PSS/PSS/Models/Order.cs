using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    [DisplayName("Pedido")]
    public abstract class Order : Base
    {
        [DisplayName("Valor total")]
        public double? TotalValue { get; set; }

        [DisplayName("Data")]
        public DateTime? Date { get; set; }

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
        public ICollection<Freight> Freights { get; set; }

        [DisplayName("Carrinho")]
        public ICollection<Item> Items { get; set; }

        [DisplayName("Pagamento")]
        public ICollection<Installment> Installments { get; set; }
    }
}