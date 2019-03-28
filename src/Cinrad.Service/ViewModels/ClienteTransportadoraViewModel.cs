using System;
using System.ComponentModel.DataAnnotations;

namespace Cinrad.Service.ViewModels
{
    public class ClienteTransportadoraViewModel
    {
        public Guid ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClienteViewModel Cliente { get; set; }
        public Guid TransportadoraId { get; set; }

        [Display(Name = "Transportadora")]
        public TransportadoraViewModel Transportadora { get; set; }

    }
}
