using Microsoft.EntityFrameworkCore;
using storeManagerDotNet.Data;
using storeManagerDotNet.Repositories;
using storeManagerDotNet.Repositories.Abstractions;

namespace storeManagerDotNet.Extensions;

public static class DataExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<StoreContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISaleProductRepository, SaleProductRepository>();
        return services;
    }

}
