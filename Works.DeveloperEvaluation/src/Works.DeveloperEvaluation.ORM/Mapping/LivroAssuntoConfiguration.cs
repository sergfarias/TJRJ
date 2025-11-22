using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Works.DeveloperEvaluation.ORM.Mapping;

public class LivroAssuntoConfiguration : IEntityTypeConfiguration<LivroAssunto>
{
    public void Configure(EntityTypeBuilder<LivroAssunto> builder)
    {
        builder.ToTable("Livro_Assunto");
        builder.HasKey(u => new { u.Livro_CodL, u.Assunto_CodAs });
        builder.Property(u => u.Livro_CodL).HasColumnType("int");
        builder.Property(u => u.Assunto_CodAs).HasColumnType("int");
    }
}
