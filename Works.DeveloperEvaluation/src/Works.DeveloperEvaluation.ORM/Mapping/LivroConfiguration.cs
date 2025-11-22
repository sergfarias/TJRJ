using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Works.DeveloperEvaluation.ORM.Mapping;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livro");
        builder.HasKey(u => u.CodL);
        builder.Property(u => u.CodL).HasColumnType("int");
        builder.Property(u => u.Titulo).IsRequired().HasMaxLength(40);
        builder.Property(u => u.Editora).IsRequired().HasMaxLength(40);
        builder.Property(u => u.Edicao);
        builder.Property(u => u.AnoPublicacao).HasMaxLength(4);
    }
}
