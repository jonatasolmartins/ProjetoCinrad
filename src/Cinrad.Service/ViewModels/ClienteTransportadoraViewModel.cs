using System;

namespace Cinrad.Service.ViewModels
{
    public class ClienteTransportadoraViewModel
    {
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public Guid TransportadoraId { get; set; }
        public TransportadoraViewModel Transportadora { get; set; }
    }
}
