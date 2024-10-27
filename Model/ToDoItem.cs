using toDoList.Enums;

namespace toDoList.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }= false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public ImportanceLevel Importance { get; set; } 
        public int CategoryId { get; set; } 
        public Category Category { get; set; } 
    }
}
