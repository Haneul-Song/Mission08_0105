using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_0105.Models;

public partial class TodosContext : DbContext
{
    public TodosContext()
    {
    }

    public TodosContext(DbContextOptions<TodosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Todos.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.Property(e => e.DueDate).HasColumnName("Due_Date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
