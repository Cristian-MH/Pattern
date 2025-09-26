using OnionShop.Application.Products;
using OnionShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/products", async (CreateProductCommand cmd, ICreateProduct svc, CancellationToken ct) =>
{
    // quick minimal validation
    if (string.IsNullOrWhiteSpace(cmd.Sku) || string.IsNullOrWhiteSpace(cmd.Name) || cmd.Price < 0)
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["Sku/Name"] = ["Required"],
            ["Price"] = ["Must be >= 0"]
        });

    var result = await svc.HandleAsync(cmd, ct);
    return Results.Created($"/products/{result.Id}", result);
});

app.Run();
