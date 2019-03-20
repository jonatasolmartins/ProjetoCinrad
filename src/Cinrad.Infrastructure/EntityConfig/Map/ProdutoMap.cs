using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("Produto");

            builder.HasKey(c => c.Id);               
            
        }

    }

}