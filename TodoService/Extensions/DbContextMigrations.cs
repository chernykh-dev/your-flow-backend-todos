using Microsoft.EntityFrameworkCore;
using TodoService.Infrastructure;

namespace TodoService.Extensions;

public static class DbContextMigrations
{
    public static void ApplyMigrations(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TodosDbContext>();
        var pendingMigrations = context.Database.GetPendingMigrations();

        if (pendingMigrations.Any())
        {
            context.Database.Migrate();
        }
    }
}