using OnionShop.Domain.Abstractions;
using OnionShop.Domain.Entities;

namespace OnionShop.Application.Products;

public sealed record CreateProductCommand(string Sku, string Name, decimal Price);
public sealed record CreateProductResult(Guid Id, string Sku, string Name, decimal Price);

public interface ICreateProduct
{
    Task<CreateProductResult> HandleAsync(CreateProductCommand cmd, CancellationToken ct);
}

public sealed class CreateProductService(IProductRepository repo) : ICreateProduct
{
    public async Task<CreateProductResult> HandleAsync(CreateProductCommand cmd, CancellationToken ct)
    {
        var existing = await repo.GetBySkuAsync(cmd.Sku, ct);
        if (existing is not null) throw new InvalidOperationException("SKU already exists.");

        var product = Product.Create(cmd.Sku, cmd.Name, cmd.Price);
        await repo.AddAsync(product, ct);
        await repo.SaveChangesAsync(ct);

        return new CreateProductResult(product.Id, product.Sku, product.Name, product.Price);
    }
}
