using Microsoft.AspNetCore.Mvc;

namespace TodoService.Requests;

public class TodoItemModel
{
    public Guid? Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public double? Order { get; set; }

    public Guid? ParentId { get; set; }
}