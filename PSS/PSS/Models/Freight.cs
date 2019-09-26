using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Freights")]
    [DisplayName("Frete")]
    public class Freight : Base
    {
        [Required]
        [DisplayName("Previsão de entrega")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [DisplayName("Valor")]
        public double Value { get; set; }

        [Required]
        [DisplayName("Tipo de frete")]
        public int FreightTypeId { get; set; }

        [DisplayName("Tipo de frete")]
        public FreightType FreightType { get; set; }
    }
}