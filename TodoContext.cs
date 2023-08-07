using Microsoft.EntityFrameworkCore;
using todoapi.Models;

namespace todoapi;

public class TodoContext:DbContext{
  
  public TodoContext(DbContextOptions<TodoContext> options):base(options){

  }

  public DbSet<Todo> TodoItems{get; set;}
  public DbSet<Category> CategoryItems{get; set;}

  protected override void OnModelCreating(ModelBuilder modelBuilder){

    modelBuilder.Entity<Todo>(todo=>{
      todo.ToTable("Todo");
      todo.HasKey(p => p.Id);
      todo.HasOne(p => p.category)
        .WithMany(q => q.todos)
        .HasForeignKey(r => r.CategoryId);
      todo.Property(p=>p.TodoText).IsRequired();
      todo.Property(p=>p.done);
    });

    modelBuilder.Entity<Category>(category=>{
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);
      category.Property(p => p.name).IsRequired();
    });
  }
}