using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<IReadOnlyList<Product>> getProductsAsync();
         Task<Product> GetProductAsync(int id);
         Task<IReadOnlyList<ProductBrand>> getProductBrandsAsync();
         Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
 
    }
}