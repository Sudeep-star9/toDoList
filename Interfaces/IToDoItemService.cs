using toDoList.Dtos;

namespace toDoList.Interfaces
{
    public interface IToDoItemService
    {
        Task<List<ToDoItemDto>> GetAllAsync();
        Task<ToDoItemDto> GetByIdAsync(int id);
        Task<ToDoItemDto> CreateAsync(CreateToDoItemDto toDoItemDto);
        Task<ToDoItemDto> UpdateAsync(int id, UpdateToDoItemDto toDoItemDto);
        Task<ToDoItemDto> DeleteAsync(int id);
    }
}
