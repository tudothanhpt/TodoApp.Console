﻿namespace TodoApp.Console;

public class TodoTask
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsCompleted { get; set; }
}