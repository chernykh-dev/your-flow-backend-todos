using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Entities;

namespace TodoService.Infrastructure;

public class TodosDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Host=todos-db;Port=5432;Database=todos-db;Username=admin;Password=admin;")
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}