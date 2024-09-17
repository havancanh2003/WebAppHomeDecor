using Microsoft.EntityFrameworkCore;
using WebAppHomeDecor.Domain.Entities;
using WebAppHomeDecor.Domain.Interfaces.Categoty;

namespace WebAppHomeDecor.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCategoryAsync(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var c = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (c != null)
            {
                c.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
           _context.Categories.Update(category);
           await _context.SaveChangesAsync();
        }
    }
}
