using Microsoft.EntityFrameworkCore;

namespace TodoApp.Console;

public class TodoDbContext : DbContext
{
    public DbSet<TodoTask> Tasks { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todo.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoTask>().ToTable("Tasks");
    }
}