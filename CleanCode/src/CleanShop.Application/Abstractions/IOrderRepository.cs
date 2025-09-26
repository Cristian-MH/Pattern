using CleanShop.Domain.Entities;

namespace CleanShop.Application.Abstractions;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken ct);
    Task<Order?> GetAsync(Guid id, CancellationToken ct);
}
