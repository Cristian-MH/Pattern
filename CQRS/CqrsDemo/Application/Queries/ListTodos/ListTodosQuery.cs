using CqrsDemo.Infrastructure;
using MediatR;

namespace CqrsDemo.Application.Queries.ListTodos;

public sealed record ListTodosQuery() : IRequest<IReadOnlyList<TodoDto>>;
