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
            List<Category> categoriesInit = new List<Category>();
            categoriesInit.Add(new Category()
                {
                    CategoryId=Guid.Parse("2642c11b-6367-4494-b0c9-9c0785be95a1"),
                    Name = "Hogar",
                    Description = "Actividades cotidianas del hogar."
                }
            );
            categoriesInit.Add(new Category()
                {
                    CategoryId=Guid.Parse("2642c11b-6367-4494-b0c9-9c0785be95a2"),
                    Name = "Universidad"
                }
            );

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
                eCategory.HasData(categoriesInit);
            });

            List<Models.Task> tasksInit = new List<Models.Task>();
            tasksInit.Add(new Models.Task()
                {
                    TaskId = Guid.Parse("2642c11b-6367-4494-b0c9-9c0785be95b1"),
                    CategoryId=Guid.Parse("2642c11b-6367-4494-b0c9-9c0785be95a1"),
                    Title = "Limpiar Cuarto",
                }
            );

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
                eTask.Property(p => p.PriorityTask)
                    .HasDefaultValue(Priority.Low);
                eTask.Property(p => p.Status)
                    .HasDefaultValue(Status.ToDo);
                eTask.Property(p => p.CreationDate)
                    .HasColumnType("DateTime")
                    .HasDefaultValueSql("GetDate()");
                eTask.Ignore(p => p.Summary);
                eTask.HasData(tasksInit);
            });
        }
    }
}