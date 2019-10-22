﻿using PSS.Utils.Constants;
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
        public System.DateTime DeliveryDate { get; set; }

        [Required]
        [DisplayName("Preço")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = General.REAL_VALUE_MASK)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Tipo de frete")]
        public int FreightTypeId { get; set; }

        [DisplayName("Tipo de frete")]
        public FreightType FreightType { get; set; }
    }
}