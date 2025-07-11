﻿namespace TodoService.Domain.Entities;

public class TodoItem
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public bool IsCompleted { get; set; }

    public string? Description { get; set; }

    public double? Order { get; set; }

    public Guid? ParentId { get; set; }
}