using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApiMvc.Repository.EFCore;

namespace WebApiMvc.Repository.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection sc
        )
    {
        var dependencias = new List<Type>();

        var typesService = typeof(WebApiMvcDbContext).Assembly
                                                     .GetTypes()
                                                     .Where(w => w.GetInterfaces().Any(a => a.Name.EndsWith("Repository")))
                                                     .ToList();

        dependencias.AddRange(typesService);

        foreach (var dep in dependencias)
        {
            var interfaces = dep.GetInterfaces();

            foreach (var inter in interfaces)
                sc.TryAddScoped(inter, dep);

        }

        return sc;

    }

    public static IServiceCollection RegisterDatabaseContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
#if DEBUG

        services.AddDbContext<WebApiMvcDbContext>(op =>
        {
            op.UseSqlite("Data Source=Contacts.db")
              .EnableSensitiveDataLogging()
              .EnableDetailedErrors()
              .LogTo(Console.WriteLine);
        });
#else
            services.AddDbContext<WebApiMvcDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                                    opt => opt.EnableRetryOnFailure()));
#endif


        return services;
    }

}
