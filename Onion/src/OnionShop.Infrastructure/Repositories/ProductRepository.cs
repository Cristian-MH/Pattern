using Microsoft.EntityFrameworkCore;
using OnionShop.Domain.Abstractions;
using OnionShop.Domain.Entities;
using OnionShop.Infrastructure.Data;

namespace OnionShop.Infrastructure.Repositories;

public sealed class ProductRepository(AppDbContext db) : IProductRepository
{
    public Task<Product?> GetBySkuAsync(string sku, CancellationToken ct) =>
        db.Products.FirstOrDefaultAsync(p => p.Sku == sku, ct);

    public Task AddAsync(Product product, CancellationToken ct) =>
        db.Products.AddAsync(product, ct).AsTask();

    public Task SaveChangesAsync(CancellationToken ct) => db.SaveChangesAsync(ct);
}
