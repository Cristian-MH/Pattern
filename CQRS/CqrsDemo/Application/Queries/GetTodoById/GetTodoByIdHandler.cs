using CqrsDemo.Infrastructure;
using MediatR;

namespace CqrsDemo.Application.Queries.GetTodoById;

public sealed class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, TodoDto?>
{
    private readonly ITodoReadRepository _readRepo;

    public GetTodoByIdHandler(ITodoReadRepository readRepo) => _readRepo = readRepo;

    public Task<TodoDto?> Handle(GetTodoByIdQuery request, CancellationToken ct)
        => _readRepo.GetAsync(request.Id, ct);
}
