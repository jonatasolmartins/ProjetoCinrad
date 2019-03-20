using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);               
            
        }

    }

}