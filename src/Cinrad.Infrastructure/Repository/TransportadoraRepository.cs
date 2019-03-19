using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;

namespace Cinrad.Infrastructure.Repository
{
    public class TransportadoraRepository : EFRepository<Transportadora>, ITransportadoraRepository
    {
        public TransportadoraRepository(CinradContext dbContext) : base(dbContext)
        {
        }
    }
}
