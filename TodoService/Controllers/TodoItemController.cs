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
    [HttpGet]
    public async Task<ActionResult<List<TodoItem>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await todoItemRepository.GetAllAsync();

        return new OkObjectResult(entities);
    }

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
    public async Task<ActionResult<Guid>> AddAsync([FromBody] TodoItemModel model, CancellationToken cancellationToken)
    {
        try
        {
            model.Id ??= Guid.NewGuid();

            var entity = model.Adapt<TodoItem>();

            await todoItemRepository.AddAsync(entity);

            await todoItemRepository.SaveChangesAsync();

            return new CreatedResult($"http://localhost:5206/api/v1/todos/{entity.Id}", entity);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] TodoItemModel model,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = await todoItemRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return new NotFoundResult();
            }

            entity.Title = model.Title;
            // TODO: Completed changes.
            entity.Description = model.Description;
            entity.Order = model.Order;
            entity.ParentId = model.ParentId;

            todoItemRepository.Update(entity);

            await todoItemRepository.SaveChangesAsync();

            return new OkResult();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> ToggleCompletedAsync([FromRoute] Guid id,
        [FromBody] ToggleCompletedRequestModel model, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await todoItemRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return new NotFoundResult();
            }

            entity.IsCompleted = model.IsCompleted;

            todoItemRepository.Update(entity);

            await todoItemRepository.SaveChangesAsync();

            return new OkResult();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await todoItemRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return new NotFoundResult();
            }

            todoItemRepository.Delete(entity);

            await todoItemRepository.SaveChangesAsync();

            return new OkResult();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}