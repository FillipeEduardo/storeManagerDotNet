using storeManagerDotNet.Services;
using storeManagerDotNet.Services.Abstractions;

namespace storeManagerDotNet.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            return services;
        }
    }
}
