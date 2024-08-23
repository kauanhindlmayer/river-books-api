using System.Reflection;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using RiverBooks.Books;
using RiverBooks.OrderProcessing;
using RiverBooks.Users;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting application...");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];

builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = builder.Configuration["Auth:JwtSecret"])
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument()
    .AddBooksModule(builder.Configuration, logger, mediatRAssemblies)
    .AddUsersModule(builder.Configuration, logger, mediatRAssemblies)
    .AddOrderProcessingModule(builder.Configuration, logger, mediatRAssemblies);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies([.. mediatRAssemblies]));

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

// This class is required for testing purposes only.
public partial class Program { }