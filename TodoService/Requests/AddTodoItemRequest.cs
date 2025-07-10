using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoService.Requests;

public class AddTodoItemRequest : IRequest<ActionResult<Guid>>
{
    public Guid? Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }
}