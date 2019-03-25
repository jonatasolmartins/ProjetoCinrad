using Cinrad.Core.Entity;
using Cinrad.Infrastructure.Map;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cinrad.Infrastructure.Data
{
    public class CinradContext : DbContext
    {
        public CinradContext(DbContextOptions<CinradContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Pedido> Pedidos  { get; set; }
        public DbSet<Produto> Produtos  { get; set; }
        public DbSet<AgendaProducao> AgendaProducoes  { get; set; }
        public DbSet<ApresentacaoProduto> ApresentacaoProdutos  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Transportadora>(new TransportadoraMap().Configure);
            modelBuilder.Entity<Pedido>(new PedidoMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            modelBuilder.Entity<AgendaProducao>(new AgendaProducaoMap().Configure);
            modelBuilder.Entity<ApresentacaoProduto>(new ApresentacaoProdutoMap().Configure);
        }

        public override int SaveChanges()
        {
            //Hey dev! se estiver estendendo essa aplicação e tiver alguma enntidade que você não quer deletar totalmente mas apenas desativar
            // faça essa entidade implementar a interface IIsDeleted e todo o resto eu já fiz aqui. pode chamar o método remover a vontade.

            // Detecta as alterações efetuadas sobre as entidades
            ChangeTracker.DetectChanges();

            // Identifica as instâncias das entidades existentes dentro do ChangeTracker com estado igual 'Deleted'             
            var markedAsDeleted = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);                   

            foreach (var item in markedAsDeleted)
            {
                //Apenas altera o estado da entidade que implementa a interface IIsDeleted.                 
                if (item.Entity is Core.Interface.IIsDeleted entity)
                {
                    //Marca a entidade como Unchanged para que nada seja feito com essas entidades
                    item.State = EntityState.Unchanged;

                    //Modifica a propiedade IsDeleted da entidade para true.
                    //Será operado um soft delete aqui
                    entity.IsDeleted = true; 

                    //Marca a entidade para ser atualizada
                    if (item.State != EntityState.Modified)
                    {                       
                        //Apartir deste ponto a entidade passa a ser marcada como Modified(To be Updated)
                        item.State = EntityState.Modified;
                        entity.IsDeleted = true;
                    }                
                    
                }
            }

            return base.SaveChanges();
        }
       
    }
}
