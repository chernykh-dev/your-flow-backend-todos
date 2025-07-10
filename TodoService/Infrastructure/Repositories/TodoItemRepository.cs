using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Entities;
using TodoService.Domain.Repositories;

namespace TodoService.Infrastructure.Repositories;

public class TodoItemRepository(TodosDbContext dbContext) : ITodoItemRepository
{
    public async Task<TodoItem?> GetByIdAsync(Guid id)
    {
        var entity = await dbContext.TodoItems
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }

    public async Task AddAsync(TodoItem item)
    {
        await dbContext.TodoItems.AddAsync(item);
    }

    public void Update(TodoItem item)
    {
        var entityEntry = dbContext.TodoItems.Entry(item);

        entityEntry.State = EntityState.Modified;
    }

    public void Delete(TodoItem item)
    {
        dbContext.Remove(item);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}