using System.Diagnostics;
using EFCoreEvents.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

// https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/events

var builder = WebApplication.CreateBuilder(args);

ConfigureConfiguration(builder.Configuration);
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app, app.Services, app.Environment);
ConfigureEndpoints(app, app.Services, app.Environment);

app.Run();

void ConfigureConfiguration(ConfigurationManager configuration)
{
}

void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddControllers();
    services.AddDbContext<TestDbContext>(options =>
    {
        options.UseInMemoryDatabase("notificationEntitiesDb");
        options.EnableSensitiveDataLogging();
        options.LogTo(OnLogMessage, LogLevel.Information, DbContextLoggerOptions.SingleLine);
    });
}

void ConfigureMiddleware(IApplicationBuilder app, IServiceProvider services, IWebHostEnvironment environment)
{
    // Required so that in-memory db is getting seeded upon creation
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<TestDbContext>();
        context.Database.EnsureCreated();
    }
}

void ConfigureEndpoints(IEndpointRouteBuilder app, IServiceProvider services, IWebHostEnvironment environment)
{
    app.MapControllers();
}

void OnLogMessage(string message)
{
    Debug.WriteLine(message);
}