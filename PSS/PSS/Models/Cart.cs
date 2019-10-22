using PSS.Utils.Constants;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PSS.Models
{
    [DisplayName("Carrinho de compras")]
    public class Cart
    {
        [DisplayName("Items")]
        public ICollection<Item> Items { get; } = new List<Item>();

        [DisplayName("Preço total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double TotalValue => Items.Sum(i => i.Price);
    }
}