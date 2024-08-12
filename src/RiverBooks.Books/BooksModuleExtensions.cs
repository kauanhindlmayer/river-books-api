using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Books.Data;
using Serilog;

namespace RiverBooks.Books;

public static class BooksModuleExtensions
{
    public static IServiceCollection AddBooksModule(
        this IServiceCollection services,
        ConfigurationManager configuration,
        ILogger logger,
        List<System.Reflection.Assembly> mediatRAssemblies)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BooksDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();
        mediatRAssemblies.Add(typeof(BooksModuleExtensions).Assembly);

        logger.Information("Books module added");
        return services;
    }
}
