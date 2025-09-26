using CleanShop.Application.Abstractions;
using CleanShop.Application.Orders;
using CleanShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// POST /orders
app.MapPost("/orders", async (CreateOrderCommand cmd, ICreateOrderUseCase useCase, CancellationToken ct) =>
{
    var result = await useCase.HandleAsync(cmd, ct);
    return Results.Created($"/orders/{result.OrderId}", result);
});

// GET /orders/{id}
app.MapGet("/orders/{id:guid}", async (Guid id, IOrderRepository repo, CancellationToken ct) =>
{
    var order = await repo.GetAsync(id, ct);
    return order is null ? Results.NotFound() : Results.Ok(new
    {
        order.Id,
        order.CustomerEmail,
        Items = order.Items.Select(i => new { i.Sku, i.Quantity, i.UnitPrice, i.Subtotal }),
        order.Total
    });
});

app.Run();