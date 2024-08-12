using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Users.Data;
using Serilog;

namespace RiverBooks.Users;

public static class UsersModuleExtensions
{
    public static IServiceCollection AddUsersModule(
        this IServiceCollection services,
        ConfigurationManager configuration,
        ILogger logger,
        List<System.Reflection.Assembly> mediatRAssemblies)
    {
        mediatRAssemblies.Add(typeof(UsersModuleExtensions).Assembly);
        services.AddPersistence(configuration);

        logger.Information("Users module added");
        return services;
    }

    public static void AddPersistence(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(connectionString));
        services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<UsersDbContext>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
    }
}
