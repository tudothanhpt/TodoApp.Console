namespace TodoApp.Console;

public interface ITodoService
{
    void AddTask(string title, string description, DateTime createdDate);
    IQueryable<TodoTask> GetTasksByDateRange(DateTime startDate, DateTime endDate);
    void EnsureDatabaseCreated();
}