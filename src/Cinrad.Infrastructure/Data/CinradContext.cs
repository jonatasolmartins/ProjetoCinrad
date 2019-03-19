using Cinrad.Core.Entity;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario")
                .HasOne<Cliente>(e => e.Cliente)                
                .WithMany(e => e.Usuarios)                
                .HasForeignKey(e => e.ClienteId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Usuario>()
                .HasOne<Transportadora>(e => e.Transportadora)
                .WithMany(e => e.Usuarios)                
                .HasForeignKey(e => e.TransportadoraId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Transportadora>().ToTable("Transportadora");
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<AgendaProducao>().ToTable("AgendaProducao");
            modelBuilder.Entity<ApresentacaoProduto>().ToTable("ApresentacaoProduto");

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
