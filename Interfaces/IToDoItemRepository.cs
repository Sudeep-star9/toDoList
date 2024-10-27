using toDoList.Model;

namespace toDoList.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<ToDoItem> CreateAsync(ToDoItem item);
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(int id);
        Task<ToDoItem> UpdateAsync(int id, ToDoItem item);
        Task<ToDoItem> DeleteAsync(int id);
    }
}
