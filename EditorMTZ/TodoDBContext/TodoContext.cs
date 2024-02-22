using EditorMTZ.Models;
using Microsoft.EntityFrameworkCore;

namespace EditorMTZ.TodoDBContext;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> todoItems { get; set; } = null;
}