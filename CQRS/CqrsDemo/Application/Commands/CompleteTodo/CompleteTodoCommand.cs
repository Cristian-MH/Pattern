using MediatR;

namespace CqrsDemo.Application.Commands.CompleteTodo;

public sealed record CompleteTodoCommand(Guid Id) : IRequest;
