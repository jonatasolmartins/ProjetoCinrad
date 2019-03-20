using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.Map
{
    public class TransportadoraMap : IEntityTypeConfiguration<Transportadora>
    {
        public void Configure(EntityTypeBuilder<Transportadora> builder)
        {

            builder.ToTable("Transportadora");

            builder.HasKey(c => c.Id);               
            
        }

    }

}