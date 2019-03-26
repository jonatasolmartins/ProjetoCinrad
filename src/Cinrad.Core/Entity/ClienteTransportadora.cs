using System;

namespace Cinrad.Core.Entity
{
    public class ClienteTransportadora
    {
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public Guid TransportadoraId { get; set; }
        public virtual Transportadora Transportadora { get; set; }
    }
}
