using Microsoft.EntityFrameworkCore;
using toDoList.Context;
using toDoList.Interfaces;
using toDoList.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace toDoList.Repositories
{
    public class ItemRepository : IToDoItemRepository
    {
        private readonly ToDoDbContext _dbContext;

        public ItemRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoItem> CreateAsync(ToDoItem item)
        {
            await _dbContext.ToDoItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.ToDoItems
                           .Include(t => t.Category)
                           .FirstOrDefaultAsync(t => t.Id == item.Id);
           
        }

        public async Task<ToDoItem> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null) return null;

            _dbContext.ToDoItems.Remove(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<List<ToDoItem>> GetAllAsync() => await _dbContext.ToDoItems.Include(t=>t.Category).ToListAsync();

        public async Task<ToDoItem> GetByIdAsync(int id) => await _dbContext.ToDoItems.Include(t => t.Category).FirstOrDefaultAsync(x=>x.Id==id);

        public async Task<ToDoItem> UpdateAsync(int id, ToDoItem item)
        {
            var existingItem = await _dbContext.ToDoItems.Include(t=>t.Category).FirstOrDefaultAsync(x => x.Id== id);
            if (existingItem == null) return null;

            existingItem.Title = item.Title;
            existingItem.Description = item.Description;
            existingItem.CategoryId = item.CategoryId;
            existingItem.Importance = item.Importance;
            existingItem.DueDate = item.DueDate;
            existingItem.IsCompleted = item.IsCompleted;

            await _dbContext.SaveChangesAsync();
            return await _dbContext.ToDoItems
            .Include(t => t.Category) 
            .FirstOrDefaultAsync(t => t.Id == existingItem.Id);
        }
    }
}
