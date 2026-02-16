using CqrsDemo.Infrastructure;
using MediatR;

namespace CqrsDemo.Application.Commands.CompleteTodo;

public sealed class CompleteTodoHandler : IRequestHandler<CompleteTodoCommand>
{
    private readonly ITodoWriteRepository _writeRepo;

    public CompleteTodoHandler(ITodoWriteRepository writeRepo) => _writeRepo = writeRepo;

    public async Task Handle(CompleteTodoCommand request, CancellationToken ct)
    {
        var item = await _writeRepo.GetAsync(request.Id, ct);
        if (item is null)
            throw new KeyNotFoundException($"Todo {request.Id} not found.");

        item.MarkDone();

        await _writeRepo.SaveChangesAsync(ct);
    }
}
