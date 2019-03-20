using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.Map
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {

            builder.ToTable("Pedido");

            builder.HasKey(c => c.Id);               
            
        }

    }

}