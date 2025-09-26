namespace CleanShop.Domain.Entities;

public sealed class OrderItem
{
    public string Sku { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }
    public decimal Subtotal => Quantity * UnitPrice;

    public OrderItem(string sku, int quantity, decimal unitPrice)
    {
        Sku = sku ?? throw new ArgumentNullException(nameof(sku));
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
