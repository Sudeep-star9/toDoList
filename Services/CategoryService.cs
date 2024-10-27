using AutoMapper;
using toDoList.Dtos;
using toDoList.Interfaces;
using toDoList.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace toDoList.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var createdCategory = await _repository.CreateAsync(category);
            return _mapper.Map<CategoryDto>(createdCategory);
        }

        public async Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            var existingItem = await _repository.GetByIdAsync(id);
            if (existingItem == null) return null;

            _mapper.Map(categoryDto, existingItem);
            var updatedItem = await _repository.UpdateAsync(existingItem.Id, existingItem);
            return _mapper.Map<CategoryDto>(updatedItem);
        }

        public async Task<CategoryDto> DeleteAsync(int id)
        {
            var category = await _repository.DeleteAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
