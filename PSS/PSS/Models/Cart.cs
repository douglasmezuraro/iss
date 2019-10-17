using System.Collections.Generic;
using System.ComponentModel;

namespace PSS.Models
{
    [DisplayName("Carrinho de compras")]
    public class Cart
    {
        [DisplayName("Items")]
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}