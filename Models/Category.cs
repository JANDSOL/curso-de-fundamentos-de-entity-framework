using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace proj_tareas_categ.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }

        [MinLength(2, ErrorMessage = "Ingresa un nombre de tarea válido")]
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}