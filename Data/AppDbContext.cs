using backend_todo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace backend_todo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoTask> Todos { get; set; }
}