using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.OrderProcessing.Data;
using Serilog;

namespace RiverBooks.OrderProcessing;

public static class OrderProcessingModuleExtensions
{
    public static IServiceCollection AddOrderProcessingModule(
        this IServiceCollection services,
        ConfigurationManager configuration,
        ILogger logger,
        List<System.Reflection.Assembly> mediatRAssemblies)
    {
        mediatRAssemblies.Add(typeof(OrderProcessingModuleExtensions).Assembly);
        services.AddPersistence(configuration);

        logger.Information("{Module} module added", "OrderProcessing");
        return services;
    }

    public static void AddPersistence(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<OrderProcessingDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
