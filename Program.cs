//Setup the DI container

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Console;


var databaseFile = "todo.db";

var services = new ServiceCollection();
ConfigureServices(services);

var serviceProvider = services.BuildServiceProvider();

if (File.Exists(databaseFile))
{
    File.Delete(databaseFile);
}

// Resolve todo service
var todoService = serviceProvider.GetRequiredService<ITodoService>();

// Create database if it does not exist
todoService.EnsureDatabaseCreated();

// Add some seed data for testing
todoService.AddTask("Buy groceries", "Milk, Eggs, Bread", DateTime.Now.AddDays(-1));
todoService.AddTask("Finish homework", "Math and Science assignments", DateTime.Now.AddDays(-5));
todoService.AddTask("Meeting with Bob", "Discuss project status", DateTime.Now.AddDays(-10));

// Retrieve tasks created within a specific date range
var startDate = DateTime.Now.AddDays(-7); // 7 days ago
var endDate = DateTime.Now; // Today

var tasks = todoService.GetTasksByDateRange(startDate, endDate).ToList();
Console.WriteLine($"Task created between {startDate.ToShortDateString()} and {endDate.ToShortDateString()} is:");
foreach (var task in tasks)
{
    Console.WriteLine($"-{task.Title} (Created on {task.CreatedAt.ToShortDateString()})");
}



void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<TodoDbContext>(options => options.UseSqlite($"Data Source={databaseFile}"));

    services.AddScoped<ITodoService, TodoService>();
}