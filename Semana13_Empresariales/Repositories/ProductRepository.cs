using Microsoft.EntityFrameworkCore;
using Semana13_Empresariales.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semana13_Empresariales.Repositories
{
    public class ProductRepository
    {
        private readonly CompanyContext _context;

        public ProductRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;  // Marcamos como eliminado lógico
                await _context.SaveChangesAsync();
            }
        }
    }
}
