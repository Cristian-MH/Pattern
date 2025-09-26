namespace OnionShop.Domain.Entities;

public sealed class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Sku { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    private Product(string sku, string name, decimal price)
    {
        Sku = sku;
        Name = name;
        Price = price;
    }

    public static Product Create(string sku, string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentException("SKU required");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        return new Product(sku, name, price);
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0) throw new ArgumentOutOfRangeException(nameof(newPrice));
        Price = newPrice;
    }
}
