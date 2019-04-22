using Cinrad.Core.Entity;
using System;
using System.Collections.Generic;

namespace Cinrad.Core.Interface.Repository
{
    public interface IClienteTransportadoraRepository : IRepository<ClienteTransportadora>
    {
        IEnumerable<Transportadora> Listar(Guid id);
    }
}
