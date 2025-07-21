using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Entities;

namespace TodoService.Infrastructure;

public class TodosDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql($"Host={configuration["DB_HOST"]};Port=5432;Database=todos-db;Username=postgres;Password=postgres;")
            .UseSnakeCaseNamingConvention();
    }
}