using CqrsDemo.Domain; 

namespace CqrsDemo.Infrastructure; 
public interface ITodoWriteRepository
{
    Task AddAsync(TodoItem item, CancellationToken ct);
    Task<TodoItem?> GetAsync(Guid id, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}