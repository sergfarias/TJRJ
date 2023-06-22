using brf_fnc_http_trigger.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices(sc =>
    {
        sc.AddScoped<IMyHttpService, MyHttpService>();
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
