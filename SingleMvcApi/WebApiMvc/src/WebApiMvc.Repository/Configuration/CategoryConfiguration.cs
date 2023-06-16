using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiMvc.Model;

namespace WebApiMvc.Repository.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category))
               .HasKey(pk => pk.Id);

        builder.Property(p => p.Id)
               .IsRequired()
               .HasColumnName("id");

        builder.Property(p => p.Description)
               .IsRequired()
               .HasColumnName("description")
               .HasColumnType("varchar(80)");

    }
}
