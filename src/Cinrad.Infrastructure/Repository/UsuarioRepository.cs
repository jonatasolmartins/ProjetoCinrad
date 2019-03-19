using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;

namespace Cinrad.Infrastructure.Repository
{
    public class UsuarioRepository : EFRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CinradContext dbContext) : base(dbContext)
        {
        }
    }
}
