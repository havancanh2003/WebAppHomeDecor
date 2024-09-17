using Microsoft.EntityFrameworkCore;
using WebAppHomeDecor.Application.Common;
using WebAppHomeDecor.Domain.Entities;
using WebAppHomeDecor.Domain.Interfaces;

namespace WebAppHomeDecor.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var p = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (p != null)
            {
                p.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> FilterProduct(int? categoryId, string productName, string sortOrder)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(productName))
            {
                query = query.Where(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            if (sortOrder == VariableConst.ASC)
            {
                query = query.OrderBy(p => p.ProductPrice);
            }
            else if (sortOrder == VariableConst.DESC)
            {
                query = query.OrderByDescending(p => p.ProductPrice);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
