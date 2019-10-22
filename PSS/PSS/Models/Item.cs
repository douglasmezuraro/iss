using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    [DisplayName("Items")]
    public class Item : Base
    {
        [Required]
        [DisplayName("Quantidade")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Price")]
        public double Price => Product == null ? 0 : Product.Price * Quantity;

        [Required]
        [DisplayName("Produto")]
        public int ProductId { get; set; }

        [DisplayName("Produto")]
        public Product Product { get; set; }
    }
}