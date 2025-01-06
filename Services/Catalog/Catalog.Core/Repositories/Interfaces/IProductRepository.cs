using Catalog.Core.Entities;

namespace Catalog.Core.Repositories.Interfaces;

public interface IProductRepository 
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProductsByname(string name);
    Task<IEnumerable<Product>> GetProductsByBrand(string brandName);
    Task<Product> CreateProduct(Product product);
    Task<bool>  UpdateProduct(Product product);
    Task<bool> DeleteProduct(Product product);

}
