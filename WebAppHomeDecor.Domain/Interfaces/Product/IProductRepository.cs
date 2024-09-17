
using WebAppHomeDecor.Domain.Entities;

namespace WebAppHomeDecor.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> FilterProduct(int? categoryId, string productName, string sortOrder);
    }
}
