using CqrsDemo.Infrastructure;
using MediatR;

namespace CqrsDemo.Application.Queries.GetTodoById;

public sealed record GetTodoByIdQuery(Guid Id) : IRequest<TodoDto?>;
