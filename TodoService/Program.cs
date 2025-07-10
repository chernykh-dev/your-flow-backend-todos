using Mapster;
using TodoService.Domain.Repositories;
using TodoService.Infrastructure;
using TodoService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddMapster();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContext<TodosDbContext>();

builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

builder.Services.AddRouting();
builder.Services.AddControllers();

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

app.UseSwagger();
app.UseSwaggerUI();

app.Run();