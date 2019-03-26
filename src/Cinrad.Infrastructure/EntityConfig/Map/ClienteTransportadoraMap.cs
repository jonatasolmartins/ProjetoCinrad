using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.EntityConfig.Map
{
    public class ClienteTransportadoraMap : IEntityTypeConfiguration<ClienteTransportadora>
    {
        public void Configure(EntityTypeBuilder<ClienteTransportadora> builder)
        {
            builder.ToTable("ClienteTransportadora");

            builder.HasKey(c => new {c.ClienteId, c.TransportadoraId });

            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.ClienteTransportadoras)
                .HasForeignKey(c => c.ClienteId);

            builder.HasOne(c => c.Transportadora)
                .WithMany(c => c.ClienteTransportadoras)
                .HasForeignKey(c => c.TransportadoraId);

        }
    }
}
