using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public enum OrderStatus
    {
        [Display(Description = "Indefinido")]
        Undefined,

        [Display(Description = "Em progresso")]
        InProgress,

        [Display(Description = "Finalizado")]
        Finished,

        [Display(Description = "Em separação")]
        InSeparation,

        [Display(Description = "Sáida para entrega")]
        OutForDelivery,

        [Display(Description = "Entregue")]
        Delivered
    }
}