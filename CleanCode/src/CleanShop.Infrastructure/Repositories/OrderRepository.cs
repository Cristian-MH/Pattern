using CleanShop.Application.Abstractions;
using CleanShop.Domain.Entities;
using CleanShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infrastructure.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;
    public OrderRepository(AppDbContext db) => _db = db;

    public Task<Order?> GetAsync(Guid id, CancellationToken ct)
        => _db.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id, ct);

    public Task AddAsync(Order order, CancellationToken ct)
        => _db.Orders.AddAsync(order, ct).AsTask();
}
