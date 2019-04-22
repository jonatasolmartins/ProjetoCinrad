using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinrad.Infrastructure.Repository
{
    public class ClienteTransportadoraRepository : EFRepository<ClienteTransportadora>, IClienteTransportadoraRepository
    {
        public ClienteTransportadoraRepository(CinradContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Transportadora> Listar(Guid id)
        {
            return _cinradContext.ClienteTransportadoras.Where(c => c.ClienteId == id).Select(c => c.Transportadora).AsEnumerable();
        }
    }
}
