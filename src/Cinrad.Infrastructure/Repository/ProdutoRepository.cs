using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;

namespace Cinrad.Infrastructure.Repository
{
    public class ProdutoRepository : EFRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CinradContext dbContext) : base(dbContext)
        {

        }
    }
}
