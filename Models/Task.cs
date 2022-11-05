using proj_tareas_categ.Utils;

namespace proj_tareas_categ.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Category Category { get; set; }
    }
}