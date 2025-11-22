using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Works.DeveloperEvaluation.ORM.Mapping;

public class LivroAutorConfiguration : IEntityTypeConfiguration<LivroAutor>
{
    public void Configure(EntityTypeBuilder<LivroAutor> builder)
    {
        builder.ToTable("Livro_Autor");
        builder.HasKey(u => new { u.Livro_CodL, u.Autor_CodAu } );
        builder.Property(u => u.Livro_CodL).HasColumnType("int");
        builder.Property(u => u.Autor_CodAu).HasColumnType("int");
    }
}
