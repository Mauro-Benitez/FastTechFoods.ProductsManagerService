using FastTechFoods.ProductsManagerService.Infraestructure;
using FastTechFoods.ProductsManagerService.Application;
using Microsoft.EntityFrameworkCore;
using FastTechFoods.ProductsManagerService.Application.Services.Implementation;
using FastTechFoods.ProductsManagerService.Application.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var envHostRabbitMqServer = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

//Confugure RabbitMq

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(envHostRabbitMqServer);
    });
});

builder.Services.AddSingleton<IRabbitMqClient, RabbitMqClient>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    db.Database.Migrate();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
