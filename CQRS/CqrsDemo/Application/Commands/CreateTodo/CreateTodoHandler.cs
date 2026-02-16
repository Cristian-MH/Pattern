using CqrsDemo.Domain;
using CqrsDemo.Infrastructure;
using MediatR;

namespace CqrsDemo.Application.Commands.CreateTodo;

public sealed class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Guid>
{
    private readonly ITodoWriteRepository _writeRepo;

    public CreateTodoHandler(ITodoWriteRepository writeRepo) => _writeRepo = writeRepo;

    public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken ct)
    {
        var item = new TodoItem(request.Title);

        await _writeRepo.AddAsync(item, ct);
        await _writeRepo.SaveChangesAsync(ct);

        return item.Id;
    }
}
