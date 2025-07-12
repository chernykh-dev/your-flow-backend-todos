using Microsoft.AspNetCore.Mvc;

namespace TodoService.Requests;

public class TodoItemModel
{
    public Guid? Id { get; set; }

    public string Title { get; set; }

    // TODO: Вынести в отдельный класс по редактированию.
    public bool? IsCompleted { get; set; }

    public string? Description { get; set; }

    public double? Order { get; set; }

    public Guid? ParentId { get; set; }
}