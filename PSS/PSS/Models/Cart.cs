using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PSS.Models
{
    [DisplayName("Carrinho de compras")]
    public class Cart
    {
        [DisplayName("Items")]
        public ICollection<Item> Items { get; } = new List<Item>();

        [DisplayName("Preço total")]
        public double TotalValue => Items.Sum(i => i.Price);
    }
}