using Cinrad.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinrad.Infrastructure.EntityConfig.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);
                
                
            builder.Property(c => c.Nome)                
                .HasColumnName("Nome")
                .HasMaxLength(30)               
                .IsRequired();

            builder.Property(c => c.Email)                
                .HasColumnName("Email")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(c => c.CPF)                
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Celular)                
                .HasColumnName("Celular")
                .HasMaxLength(11)
                .IsRequired(false);
            
            builder.Property(c => c.Telefone)                
                .HasColumnName("Telefone")
                .HasMaxLength(20)
                .IsRequired(false);
            
            builder.Property(c => c.IsDeleted)
                .HasColumnName("Ativo")
                .IsRequired();
            
            builder.HasOne<Cliente>(c => c.Cliente)
                    .WithMany(c => c.Usuarios)
                    .HasForeignKey(c => c.ClienteId)                    
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull);                    

            builder.HasOne<Transportadora>(e => e.Transportadora)
                    .WithMany(e => e.Usuarios)                
                    .HasForeignKey(e => e.TransportadoraId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }

    }

}