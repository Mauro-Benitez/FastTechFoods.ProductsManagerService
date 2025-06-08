using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastTechFoods.ProductsManagerService.Domain.Repositories;
using FastTechFoods.ProductsManagerService.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;


namespace FastTechFoods.ProductsManagerService.Infraestructure
{
    public static class InfraestructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddRepositories();

            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbProduct");            

            services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
           
            services.AddScoped<IProductRepository, ProductRepository>();            
            return services;
        }
    }
}

