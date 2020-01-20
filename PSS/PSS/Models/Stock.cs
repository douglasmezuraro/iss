using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Stock")]
    public sealed class Stock : Base
    {
        [DisplayName("Quantidade")]
        public int Quantity { get; set; } = 0;

        [DisplayName("Entrada")]
        public int In { get; set; } = 0;

        [DisplayName("Saída")]
        public int Out { get; set; } = 0;

        [DisplayName("Data")]
        public DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public int? ProductId { get; set; }

        public static List<Stock> InitialStock() => new List<Stock> { new Stock { Quantity = 0, Date = System.DateTime.Now } };
    }
}