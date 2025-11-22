using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Works.DeveloperEvaluation.ORM.Mapping;

public class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("Autor");
        builder.HasKey(u => u.CodAu);
        builder.Property(u => u.CodAu).HasColumnType("int");
        builder.Property(u => u.Nome).IsRequired().HasMaxLength(40);  
    }
}
