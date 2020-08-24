using core.Entities;
using  System.Collections.Generic;
using System.Threading.Tasks;
using core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class productRepository : IproductRepository
    {
        private readonly StoreContext _context;

        public productRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
             return await _context.productBrands.ToListAsync();
        }

        public async Task<product> GetProductByIdAsync(int id)
        {
            return await _context.products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p =>p.Id==id);
        }

        public  async Task<IReadOnlyList<product>> GetProductsAsync()
        {
            return await _context.products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public  async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
           return await _context.productsType.ToListAsync();
        }
    }
}