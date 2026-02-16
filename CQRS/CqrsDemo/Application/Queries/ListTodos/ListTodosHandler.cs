using CqrsDemo.Infrastructure;
using MediatR;

namespace CqrsDemo.Application.Queries.ListTodos;

public sealed class ListTodosHandler : IRequestHandler<ListTodosQuery, IReadOnlyList<TodoDto>>
{
    private readonly ITodoReadRepository _readRepo;

    public ListTodosHandler(ITodoReadRepository readRepo) => _readRepo = readRepo;

    public Task<IReadOnlyList<TodoDto>> Handle(ListTodosQuery request, CancellationToken ct)
        => _readRepo.ListAsync(ct);
}
