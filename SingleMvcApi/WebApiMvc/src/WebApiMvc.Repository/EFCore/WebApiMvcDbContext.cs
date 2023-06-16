using Microsoft.EntityFrameworkCore;
using WebApiMvc.Model;

namespace WebApiMvc.Repository.EFCore;

public class WebApiMvcDbContext : DbContext
{
    #region Properties
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    #endregion

    #region Constructor

    public WebApiMvcDbContext()
    {
        
    }

    public WebApiMvcDbContext(
        DbContextOptions<WebApiMvcDbContext> options
        )
    : base(options)
    {
    }

    #endregion


    #region Methods
    protected override void OnModelCreating(
        ModelBuilder modelBuilder
        )
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebApiMvcDbContext).Assembly);
    }
    #endregion
}