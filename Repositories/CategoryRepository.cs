using Microsoft.EntityFrameworkCore;
using toDoList.Context;
using toDoList.Interfaces;
using toDoList.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace toDoList.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ToDoDbContext _context;

        public CategoryRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

        public async Task<Category> GetByIdAsync(int id) => await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            var existingCategory= await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x=> x.Id==id);
            if (category == null) return null;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
