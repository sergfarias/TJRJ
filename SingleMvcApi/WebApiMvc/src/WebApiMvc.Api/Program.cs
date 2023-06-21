using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add Azure keyvault

if (! builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureAppConfiguration(webBuilder =>
    {
        webBuilder.AddAzureKeyVault(new Uri(builder.Configuration["KeyVaultEndpoint"]),
                          new DefaultAzureCredential());
    });
}

// Add services to the container.

builder.Services.RegisterDatabaseContext(builder.Configuration)
                .AddRepositories()
                .AddServices();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

 // Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment())
 {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
