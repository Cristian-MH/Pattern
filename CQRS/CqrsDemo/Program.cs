using CqrsDemo.Infrastructure;
using MediatR;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


builder.Services.AddSingleton<InMemoryTodoStore>();
builder.Services.AddSingleton<ITodoWriteRepository>(sp => sp.GetRequiredService<InMemoryTodoStore>());
builder.Services.AddSingleton<ITodoReadRepository>(sp => sp.GetRequiredService<InMemoryTodoStore>());

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference(); 

app.MapControllers();

app.Run();
