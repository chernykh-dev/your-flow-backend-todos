using Mapster;
using Microsoft.AspNetCore.Mvc;
using TodoService.Domain.Entities;
using TodoService.Domain.Repositories;
using TodoService.Requests;

namespace TodoService.Controllers;

[ApiController]
[Route("/api/v1/todos")]
public class TodoItemController(ITodoItemRepository todoItemRepository) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoItem>> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await todoItemRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddAsync([FromBody] AddTodoItemRequest request, CancellationToken cancellationToken)
    {
        try
        {
            request.Id ??= Guid.NewGuid();

            var entity = request.Adapt<TodoItem>();

            await todoItemRepository.AddAsync(entity);

            await todoItemRepository.SaveChangesAsync();

            // return new CreatedResult($"http://localhost:5206/api/v1/todos/{entity.Id}", entity);
            return new CreatedAtActionResult(nameof(GetAsync), "api/v1/todos",
                new { id = entity.Id }, entity);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}