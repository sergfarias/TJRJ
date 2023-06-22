using brf_fnc_complex_work.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices(sc =>
    {
        sc.AddScoped<IComplexTask, ComplexTask>();
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
