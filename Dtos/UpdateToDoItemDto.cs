using System.ComponentModel.DataAnnotations;
using toDoList.Enums;

namespace toDoList.Dtos
{
    public class UpdateToDoItemDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Due date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Importance level is required.")]
        public ImportanceLevel Importance { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
    }
}
