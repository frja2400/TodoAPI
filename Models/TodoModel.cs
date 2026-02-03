using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class TodoModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; } = null!;

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Ej påbörjad"; // Standardvärde
    }
}