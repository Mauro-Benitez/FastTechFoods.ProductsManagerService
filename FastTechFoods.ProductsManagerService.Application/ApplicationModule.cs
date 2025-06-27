using FastTechFoods.ProductsManagerService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FastTechFoods.ProductsManagerService.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
