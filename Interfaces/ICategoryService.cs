using toDoList.Dtos;

namespace toDoList.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto categoryDto);
        Task<CategoryDto> DeleteAsync(int id);
        
    }
}
