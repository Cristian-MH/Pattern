using CqrsDemo.Domain;
using System.Collections.Concurrent;

namespace CqrsDemo.Infrastructure;

public sealed class InMemoryTodoStore : ITodoWriteRepository, ITodoReadRepository
{
    private readonly ConcurrentDictionary<Guid, TodoItem> _items = new();

    public Task AddAsync(TodoItem item, CancellationToken ct)
    {
        _items[item.Id] = item;
        return Task.CompletedTask;
    }

    public Task<TodoItem?> GetAsync(Guid id, CancellationToken ct)
    {
        _items.TryGetValue(id, out var item);
        return Task.FromResult(item);
    }

    public Task SaveChangesAsync(CancellationToken ct) => Task.CompletedTask;

    Task<TodoDto?> ITodoReadRepository.GetAsync(Guid id, CancellationToken ct)
    {
        _items.TryGetValue(id, out var item);
        return Task.FromResult(item is null ? null : new TodoDto(item.Id, item.Title, item.IsDone));
    }

    public Task<IReadOnlyList<TodoDto>> ListAsync(CancellationToken ct)
    {
        IReadOnlyList<TodoDto> list = _items.Values
            .OrderBy(x => x.Title)
            .Select(x => new TodoDto(x.Id, x.Title, x.IsDone))
            .ToList();

        return Task.FromResult(list);
    }
}
