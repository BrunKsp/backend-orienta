using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration : BaseConfiguration<UsuarioEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("usuarios");

        builder.Property(u => u.Nome)
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(u => u.Senha)
            .HasColumnName("senha")
            .IsRequired();

        builder.Property(u => u.Foto)
           .HasColumnName("foto");

        builder.Property(u => u.Slug)
            .HasColumnName("slug")
            .IsRequired();

        builder.Property(u => u.TipoUsuario)
            .HasColumnName("tipo_usuario")
            .IsRequired();
    }
}