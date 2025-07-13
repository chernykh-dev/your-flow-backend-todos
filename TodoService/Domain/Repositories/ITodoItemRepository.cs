using TodoService.Domain.Entities;

namespace TodoService.Domain.Repositories;

public interface ITodoItemRepository
{
    Task<List<TodoItem>> GetAllAsync();

    Task<List<TodoItem>> GetAllSortedAsync();

    Task<TodoItem?> GetByIdAsync(Guid id);

    Task AddAsync(TodoItem item);

    void Update(TodoItem item);

    void Delete(TodoItem item);

    Task SaveChangesAsync();
}