using toDoList.Enums;
using toDoList.Model;

namespace toDoList.Dtos
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; } // New property for due date
        public ImportanceLevel Importance { get; set; } // New property for importance
        public int CategoryId { get; set; } // Foreign key for category
        public CategoryDto Category { get; set; } // Naviga
    }
}
