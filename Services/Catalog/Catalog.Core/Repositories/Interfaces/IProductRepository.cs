using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories.Interfaces;

public interface IProductRepository 
{
    Task<Pagination<Product>> GetAllProducts(CatalogueSpecParam specs);
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProductsByname(string name);
    Task<IEnumerable<Product>> GetProductsByBrand(string brandName);
    Task<Product> CreateProduct(Product product);
    Task<bool>  UpdateProduct(Product product);
    Task<bool> DeleteProduct(Product product);

}
