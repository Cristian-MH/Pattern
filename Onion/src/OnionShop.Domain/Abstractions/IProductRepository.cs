using OnionShop.Domain.Entities;

namespace OnionShop.Domain.Abstractions;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken ct);
    Task<Product?> GetBySkuAsync(string sku, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}
