using Microsoft.EntityFrameworkCore;
using proj_tareas_categ.Models;
using proj_tareas_categ.Utils;

namespace proj_tareas_categ.Contexts
{
    public class ContextTasks : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public ContextTasks(DbContextOptions<ContextTasks> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .Property(prop => prop.TaskId)
                .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Models.Task>()
                .Property(prop => prop.Description)
                .HasDefaultValue("");
            modelBuilder.Entity<Models.Task>()
                .Property(prop => prop.PriorityTask)
                .HasDefaultValue(Priority.Low);
            modelBuilder.Entity<Models.Task>()
                .Property(prop => prop.CreationDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Category>()
                .Property(prop => prop.CategoryId)
                .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Category>()
                .Property(prop => prop.Description)
                .HasDefaultValue("");
        }
    }
}