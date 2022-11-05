using Microsoft.EntityFrameworkCore;
using proj_tareas_categ.Models;
using Task = proj_tareas_categ.Models.Task;

namespace proj_tareas_categ.Contexts
{
    public class ContextTasks : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public ContextTasks(DbContextOptions<ContextTasks> options) : base(options) { }
    }
}