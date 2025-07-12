using Mapster;
using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Repositories;
using TodoService.Extensions;
using TodoService.Infrastructure;
using TodoService.Infrastructure.Repositories;

namespace TodoService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMapster();

        builder.Services.AddDbContext<TodosDbContext>();

        builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        builder.Services.AddRouting();
        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "allow_all",
                policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
        });

        builder.Services.AddLogging();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // app.UseHttpsRedirection();
        app.UseRouting();
        app.MapControllers();

        app.UseCors("allow_all");

        app.UseSwagger();
        app.UseSwaggerUI();

        app.ApplyMigrations();

        app.Run();
    }
}