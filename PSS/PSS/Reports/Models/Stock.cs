using System;
using System.ComponentModel;

namespace PSS.Reports.Models
{
    public sealed class Stock
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Descrição do produto")]
        public string Description { get; set; }

        [DisplayName("Estoque atual")]
        public int? Actual { get; set; }

        [DisplayName("Entrada")]
        public int? Entry { get; set; }

        [DisplayName("Saída")]
        public int? Out { get; set; }

        [DisplayName("Data da movimentação")]
        public DateTime? Date { get; set; }

        [DisplayName("Estoque anterior")]
        public int? Previous { get; set; }
    }
}