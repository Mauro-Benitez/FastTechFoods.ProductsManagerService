using FastTechFoods.ProductsManagerService.Application.IMessaging;
using FastTechFoods.ProductsManagerService.Domain.Repositories;
using FastTechFoods.ProductsManagerService.Infraestructure.Messaging;
using FastTechFoods.ProductsManagerService.Infraestructure.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OrderService.Contracts.Events;
using System.Text;

namespace FastTechFoods.ProductsManagerService.Infraestructure
{
    public static class InfraestructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddMessaging()
                .AddRepositories();

            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_DATABASE") ??
                configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            var envHostRabbitMqServer = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Message<CreateProductEvent>(x =>
                    {
                        x.SetEntityName("create-product-event");
                    });

                    cfg.Message<DeleteProductEvent>(x =>
                    {
                        x.SetEntityName("delete-product-event");
                    });

                    cfg.Message<UpdateProductEvent>(x =>
                    {
                        x.SetEntityName("update-product-event");
                    });

                    cfg.Host(envHostRabbitMqServer);
                });

            });
            services.AddScoped<ICreateProductEventPublisher, CreateProductEventPublisher>();
            services.AddScoped<IUpdateProductEventPublisher, UpdateProductEventPublisher>();
            services.AddScoped<IDeleteProductEventPublisher, DeleteProductEventPublisher>();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
           
            services.AddScoped<IProductRepository, ProductRepository>();            
            return services;
        }


        private static IServiceCollection AddAutentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtKey = configuration["Jwt:Key"];

            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(jwtKey)
                    )
                };
            });

            services.AddAuthorization();

            return services;
        }


    }
}

