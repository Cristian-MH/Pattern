using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionShop.Application.Products;
using OnionShop.Domain.Abstractions;
using OnionShop.Infrastructure.Data;
using OnionShop.Infrastructure.Repositories;

namespace OnionShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString = null)
    {
        // Quick start: InMemory DB (swap for UseSqlServer(connectionString) later)
        services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("onionshop"));

        // Ports → Adapters
        services.AddScoped<IProductRepository, ProductRepository>();

        // Application services
        services.AddScoped<ICreateProduct, CreateProductService>();

        return services;
    }
}
