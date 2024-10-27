using AutoMapper;
using toDoList.Dtos;
using toDoList.Interfaces;
using toDoList.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace toDoList.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _repository;
        private readonly IMapper _mapper;

        public ToDoItemService(IToDoItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ToDoItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<List<ToDoItemDto>>(items);
        }

        public async Task<ToDoItemDto> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<ToDoItemDto>(item);
        }

        public async Task<ToDoItemDto> CreateAsync(CreateToDoItemDto toDoItemDto)
        {
            var item = _mapper.Map<ToDoItem>(toDoItemDto);
             await _repository.CreateAsync(item);
            return _mapper.Map<ToDoItemDto>(item);
        }

        public async Task<ToDoItemDto> UpdateAsync(int id, UpdateToDoItemDto toDoItemDto)
        {
            var existingItem = await _repository.GetByIdAsync(id);
            if (existingItem == null) return null;

            _mapper.Map(toDoItemDto, existingItem);
            var updatedItem = await _repository.UpdateAsync(existingItem.Id, existingItem);
            return _mapper.Map<ToDoItemDto>(updatedItem);
        }

        public async Task<ToDoItemDto> DeleteAsync(int id)
        {
            var item = await _repository.DeleteAsync(id);
            return _mapper.Map<ToDoItemDto>(item);
        }

        
    }
}
