using MediatR;

namespace CqrsDemo.Application.Commands.CreateTodo;

public sealed record CreateTodoCommand(string Title) : IRequest<Guid>;
