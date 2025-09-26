using CleanShop.Application.Abstractions;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Orders;

public sealed record CreateOrderItemDto(string Sku, int Quantity, decimal UnitPrice);
public sealed record CreateOrderCommand(string CustomerEmail, IReadOnlyList<CreateOrderItemDto> Items);
public sealed record CreateOrderResult(Guid OrderId, decimal Total);

public interface ICreateOrderUseCase
{
    Task<CreateOrderResult> HandleAsync(CreateOrderCommand cmd, CancellationToken ct);
}

public sealed class CreateOrderUseCase : ICreateOrderUseCase
{
    private readonly IOrderRepository _repo;
    private readonly IUnitOfWork _uow;

    public CreateOrderUseCase(IOrderRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<CreateOrderResult> HandleAsync(CreateOrderCommand cmd, CancellationToken ct)
    {
        var order = Order.Create(cmd.CustomerEmail);
        foreach (var i in cmd.Items)
            order.AddItem(i.Sku, i.Quantity, i.UnitPrice);

        await _repo.AddAsync(order, ct);
        await _uow.SaveChangesAsync(ct);

        return new CreateOrderResult(order.Id, order.Total);
    }
}
