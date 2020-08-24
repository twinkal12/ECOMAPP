
using core.Entities;
using  System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Interface
{
    public interface IproductRepository 
    {
        Task<product> GetProductByIdAsync(int id);
        
        Task<IReadOnlyList<product>> GetProductsAsync();
          Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
            Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        
    }
}