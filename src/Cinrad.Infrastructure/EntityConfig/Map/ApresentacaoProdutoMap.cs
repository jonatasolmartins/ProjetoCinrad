using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.EntityConfig.Map
{
    public class ApresentacaoProdutoMap : IEntityTypeConfiguration<ApresentacaoProduto>
    {
        public void Configure(EntityTypeBuilder<ApresentacaoProduto> builder)
        {

            builder.ToTable("ApresentacaoProduto");

            builder.HasKey(c => c.Id);               
            
        }

    }

}