using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.Map
{
    public class AgendaProducaoMap : IEntityTypeConfiguration<AgendaProducao>
    {
        public void Configure(EntityTypeBuilder<AgendaProducao> builder)
        {

            builder.ToTable("AgendaProducao");

            builder.HasKey(c => c.Id);               
            
        }

    }

}