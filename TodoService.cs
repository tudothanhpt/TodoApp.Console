namespace TodoApp.Console;

public class TodoService : ITodoService
{
    private readonly TodoDbContext _todoDbContext;

    public TodoService(TodoDbContext todoDbContext)
    {
        _todoDbContext = todoDbContext;
    }

    public void AddTask(string title, string description, DateTime createdDate)
    {
        var task = new TodoTask()
        {
            Title = title,
            Description = description,
            CreatedAt = createdDate,
            IsCompleted = false
        };

        _todoDbContext.Add(task);
        _todoDbContext.SaveChanges();
    }

    public IQueryable<TodoTask> GetTasksByDateRange(DateTime startDate, DateTime endDate)
    {
        return _todoDbContext.Tasks
            .Where(tasks => tasks.CreatedAt >= startDate && tasks.CreatedAt <= endDate)
            .OrderBy(tasks => tasks.CreatedAt);
    }

    public void EnsureDatabaseCreated()
    {
        _todoDbContext.Database.EnsureCreated();
    }
}