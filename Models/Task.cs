using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using proj_tareas_categ.Utils;

namespace proj_tareas_categ.Models
{
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        [
            Required(ErrorMessage = "Ingresa un título para la categoria"),
            MinLength(2, ErrorMessage = "Ingresa un título de categoria válido"),
            MaxLength(200, ErrorMessage = "¡Superaste el límite de caracteres!")
        ]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "¡Superaste el límite de caracteres!")]
        public string? Description { get; set; }

        public Priority PriorityTask { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(
            ApplyFormatInEditMode = true,
            DataFormatString = "{g}")
        ]
        public DateTime CreationDate { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public string Summary { get; set; }
    }
}