using System.ComponentModel.DataAnnotations;

namespace proj_tareas_categ.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [
            Required(ErrorMessage = "Ingresa un nombre para la tarea"),
            MinLength(2, ErrorMessage = "Ingresa un nombre de tarea válido"),
            MaxLength(150, ErrorMessage = "¡Superaste el límite de caracteres!")
        ]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "¡Superaste el límite de caracteres!")]
        public string Description { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}