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
            modelBuilder.Entity<Category>(eCategory =>
            {
                eCategory.ToTable("Category");
                eCategory.HasKey(p => p.CategoryId);
                eCategory.Property(p => p.CategoryId)
                    .HasDefaultValueSql("NewId()");
                eCategory.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(150);
                eCategory.Property(p => p.Description)
                    .IsRequired(false)
                    .HasMaxLength(500)
                    .HasDefaultValue("");
            });

            modelBuilder.Entity<Models.Task>(eTask =>
            {
                eTask.ToTable("Task");
                eTask.HasKey(p => p.TaskId);
                eTask.Property(p => p.TaskId)
                    .HasDefaultValueSql("NewId()");
                eTask.HasOne(p => p.Category)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(p => p.CategoryId);
                eTask.Property(p => p.Title)
                    .IsRequired()
                    .HasMaxLength(150);
                eTask.Property(p => p.Description)
                    .IsRequired(false)
                    .HasMaxLength(500)
                    .HasDefaultValue("");
                eTask.Property(eTask => eTask.PriorityTask)
                    .HasDefaultValue(Priority.Low);
                eTask.Property(eTask => eTask.CreationDate)
                    .HasColumnType("DateTime")
                    .HasDefaultValueSql("GetDate()");
                eTask.Ignore(p => p.Summary);
            });
        }
    }
}