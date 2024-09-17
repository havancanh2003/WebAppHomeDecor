using WebAppHomeDecor.Domain.Entities;

namespace WebAppHomeDecor.Domain.Interfaces.Categoty
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
