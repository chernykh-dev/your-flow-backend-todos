using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoService.Domain.Entities;

namespace TodoService.Requests;

public class GetTodoItemByIdRequest : IRequest<ActionResult<TodoItem>>
{
    public Guid Id { get; set; }
}