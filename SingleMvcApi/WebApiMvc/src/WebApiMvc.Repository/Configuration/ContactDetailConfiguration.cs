using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiMvc.Model;

namespace WebApiMvc.Repository.Configuration;

public class ContactDetailConfiguration : IEntityTypeConfiguration<ContactDetail>
{
    public void Configure(EntityTypeBuilder<ContactDetail> builder)
    {
        builder.ToTable(nameof(ContactDetail))
               .HasKey(pk => pk.Id);

        builder.Property(p => p.Id)
               .IsRequired()
               .HasColumnName("id");

        builder.Property(p => p.Email)               
               .HasColumnName("email")
               .HasColumnType("varchar(80)");

        builder.Property(p => p.CelPhone)
               .IsRequired()
               .HasColumnName("cell_phone")
               .HasColumnType("varchar(80)");

        builder.Property(p => p.PhoneNumber)               
               .HasColumnName("phone_number")
               .HasColumnType("varchar(80)");

        builder.Property(p => p.Linkedin)               
               .HasColumnName("linkedin")
               .HasColumnType("varchar(80)");


    }
}
