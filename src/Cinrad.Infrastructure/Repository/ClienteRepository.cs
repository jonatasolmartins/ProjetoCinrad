using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;

namespace Cinrad.Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CinradContext dbContext) : base(dbContext)
        {
        }
    }
}
