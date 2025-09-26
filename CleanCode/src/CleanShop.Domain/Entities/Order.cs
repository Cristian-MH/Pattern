using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanShop.Domain.Entities;

public sealed class Order
{
    private readonly List<OrderItem> _items = new();
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string CustomerEmail { get; private set; }
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    public decimal Total => _items.Sum(i => i.Subtotal);

    private Order(string customerEmail) => CustomerEmail = customerEmail;

    public static Order Create(string customerEmail)
    {
        if (string.IsNullOrWhiteSpace(customerEmail))
            throw new ArgumentException("Customer email is required.");
        return new Order(customerEmail);
    }

    public void AddItem(string sku, int qty, decimal unitPrice)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        _items.Add(new OrderItem(sku, qty, unitPrice));
    }
}
