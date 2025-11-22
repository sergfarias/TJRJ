using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Works.DeveloperEvaluation.ORM.Mapping;

public class AssuntoConfiguration : IEntityTypeConfiguration<Assunto>
{
    public void Configure(EntityTypeBuilder<Assunto> builder)
    {
        builder.ToTable("Assunto");
        builder.HasKey(u => u.CodAs);
        builder.Property(u => u.CodAs).HasColumnType("int");
        builder.Property(u => u.Descricao).IsRequired().HasMaxLength(20);
    }
}
