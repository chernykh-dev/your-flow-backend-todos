using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoService.Domain.Entities;
using TodoService.Domain.Repositories;
using TodoService.Requests;

namespace TodoService.Controllers;

[ApiController]
[Route("/api/v1/todos")]
public class TodoItemController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoItem>> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetTodoItemByIdRequest { Id = id }, cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddAsync([FromBody] AddTodoItemRequest request, CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }
}