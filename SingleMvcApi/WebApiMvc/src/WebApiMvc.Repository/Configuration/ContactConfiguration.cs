using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiMvc.Model;
using WebApiMvc.Model.Enums;

namespace WebApiMvc.Repository.Configuration;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable(nameof(Contact))
               .HasKey(pk => pk.Id);

        builder.Property(p => p.Id)
               .IsRequired()
               .HasColumnName("id");

        builder.Property(p => p.Status)
               .IsRequired()
               .HasColumnName("status")
               .HasColumnType("varchar(30)")
               .HasConversion(
                 v => v.ToString(),
                 v => (EStatus)Enum.Parse(typeof(EStatus), v));

        builder.HasOne(p => p.Category)               
               .WithMany()
               .HasForeignKey(d => d.CategoryId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("fk_Contact_Category");        

        builder.Property(p => p.Name)
               .IsRequired()
               .HasColumnName("name")
               .HasColumnType("varchar(80)");

        builder.OwnsOne(p => p.Address)
               .Property(p => p.Address)
               .HasColumnName("address")
               .HasColumnType("varvar(80)");

        builder.OwnsOne(p => p.Address)
               .Property(p => p.Number)
               .HasColumnName("number")
               .HasColumnType("varvar(20)");

        builder.OwnsOne(p => p.Address)
               .Property(p => p.Neighborhood)
               .HasColumnName("neighborhood")
               .HasColumnType("varvar(80)");

        builder.OwnsOne(p => p.Address)
               .Property(p => p.City)
               .HasColumnName("city")
               .HasColumnType("varvar(80)");

        builder.OwnsOne(p => p.Address)
               .Property(p => p.State)
               .HasColumnName("state")
               .HasColumnType("varvar(20)");

        builder.OwnsOne(p => p.Address)
               .Property(p => p.ZipCode)
               .HasColumnName("zip_code")
               .HasColumnType("varvar(20)");

        builder.HasMany(p => p.ContactsDetails)
               .WithOne(p => p.Contact)
               .HasForeignKey(d => d.ContactId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_Contact_ContactsDetails"); 


    }
}
