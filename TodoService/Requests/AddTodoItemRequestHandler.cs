using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoService.Controllers;
using TodoService.Domain.Entities;
using TodoService.Domain.Repositories;

namespace TodoService.Requests;

public class AddTodoItemRequestHandler(ITodoItemRepository todoItemRepository) : IRequestHandler<AddTodoItemRequest, ActionResult<Guid>>
{
    public async Task<ActionResult<Guid>> Handle(AddTodoItemRequest request, CancellationToken cancellationToken)
    {
        try
        {
            request.Id ??= Guid.NewGuid();

            var entity = request.Adapt<TodoItem>();

            await todoItemRepository.AddAsync(entity);

            await todoItemRepository.SaveChangesAsync();

            return new CreatedResult($"http://localhost:5206/api/v1/todos/{entity.Id}", entity);
        }
        catch (Exception ex)
        {
            return new BadRequestResult();
        }
    }
}