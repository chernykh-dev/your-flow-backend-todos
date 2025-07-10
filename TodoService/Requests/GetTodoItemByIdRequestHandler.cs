using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoService.Domain.Entities;
using TodoService.Domain.Repositories;

namespace TodoService.Requests;

public class GetTodoItemByIdRequestHandler(ITodoItemRepository todoItemRepository) : IRequestHandler<GetTodoItemByIdRequest, ActionResult<TodoItem>>
{
    public async Task<ActionResult<TodoItem>> Handle(GetTodoItemByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await todoItemRepository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(entity);
    }
}