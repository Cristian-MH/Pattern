namespace CqrsDemo.Infrastructure;

public sealed record TodoDto(Guid Id, string Title, bool IsDone);

public interface ITodoReadRepository
{
    Task<TodoDto?> GetAsync(Guid id, CancellationToken ct);
    Task<IReadOnlyList<TodoDto>> ListAsync(CancellationToken ct);
}
