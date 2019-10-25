using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Indefinido")]
        Undefined,

        [Display(Name = "Em progresso")]
        InProgress,

        [Display(Name = "Finalizado")]
        Finished,

        [Display(Name = "Em separação")]
        InSeparation,

        [Display(Name = "Sáida para entrega")]
        OutForDelivery,

        [Display(Name = "Entregue")]
        Delivered
    }
}