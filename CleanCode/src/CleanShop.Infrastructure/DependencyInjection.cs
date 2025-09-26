using CleanShop.Application.Abstractions;
using CleanShop.Application.Orders;
using CleanShop.Infrastructure.Data;
using CleanShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString = null)
    {
        // InMemory by default for quick start; swap to UseSqlServer(connectionString) later
        services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("cleanshop"));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
        return services;
    }
}
