using System.ComponentModel.DataAnnotations;
using proj_tareas_categ.Utils;

namespace proj_tareas_categ.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }

        public Guid CategoryId { get; set; }

        [MinLength(2, ErrorMessage = "Ingresa un título de categoria válido")]
        public string Title { get; set; }

        public string Description { get; set; }

        public Priority PriorityTask { get; set; }

        [
            DisplayFormat(
                ApplyFormatInEditMode = true,
                DataFormatString = "{g}"
            )
        ]
        public DateTime CreationDate { get; set; }

        public string Summary { get; set; }

        public virtual Category Category { get; set; }
    }
}