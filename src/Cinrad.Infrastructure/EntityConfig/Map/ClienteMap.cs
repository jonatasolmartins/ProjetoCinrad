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

            builder.Property(c => c.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.Cnpj)
               .HasColumnName("Cnpj")
               .HasMaxLength(14)              
               .IsRequired();

            builder.Property(c => c.NomeFantasia)
                .HasColumnName("NomeFantasia")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(c => c.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(20);

            builder.Property(c => c.Site)
                .HasColumnName("Site")
                .HasMaxLength(100)
                .IsRequired(false);

        }

    }

}