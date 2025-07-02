using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Entities;

namespace DataAccess;

public class TodoDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Customize your schema if required
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Todo>().ToTable("Todos");
    }
}