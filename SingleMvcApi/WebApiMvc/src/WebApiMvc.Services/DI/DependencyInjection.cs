using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebApiMvc.Services.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(
        this IServiceCollection sc
        )
    {
        var dependencias = new List<Type>();

        var typesService = typeof(CategoryService).Assembly
                                                  .GetTypes()
                                                  .Where(w => w.GetInterfaces().Any(a => a.Name.EndsWith("Service")))
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

}
