using Microsoft.EntityFrameworkCore;
using TodoItems.Models;

namespace TodoItems.DataContext;

public class TodoDBContext : DbContext
{
    public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
}