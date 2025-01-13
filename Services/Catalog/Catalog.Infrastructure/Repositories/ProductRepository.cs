using Catalog.Core.Entities;
using Catalog.Core.Repositories.Interfaces;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;
/// <summary>
/// Repository class that implements data access operations for Products, Brands and Types
/// using MongoDB as the data store
/// </summary>
public class ProductRepository : IProductRepository, IBrandRepository, ITypeRepository
{
    private readonly ICatalogContext _catalogContext;

    /// <summary>
    /// Constructor that injects the catalog context dependency
    /// </summary>
    /// <param name="catalogContext">MongoDB catalog context</param>
    public ProductRepository(ICatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }

    /// <summary>
    /// Creates a new product in the database
    /// </summary>
    /// <param name="product">Product entity to create</param>
    /// <returns>The created product</returns>
    async Task<Product> IProductRepository.CreateProduct(Product product)
    {
       await _catalogContext.Products.InsertOneAsync(product);
       return product;
    }

    /// <summary>
    /// Deletes a product from the database
    /// </summary>
    /// <param name="product">Product entity to delete</param>
    /// <returns>True if delete was successful, false otherwise</returns>
    async Task<bool> IProductRepository.DeleteProduct(Product product)
    {
        var deletedproduct = await _catalogContext.Products.DeleteOneAsync(p => p.Id == product.Id);
        return deletedproduct.IsAcknowledged && deletedproduct.DeletedCount > 0;
    }

    /// <summary>
    /// Retrieves all product brands from the database
    /// </summary>
    /// <returns>Collection of all product brands</returns>
    async Task<IEnumerable<ProductBrand>> IBrandRepository.GetAllBrands()
    {
        return await _catalogContext.Brands.Find(p => true).ToListAsync();
    }

    /// <summary>
    /// Retrieves all products from the database
    /// </summary>
    /// <returns>Collection of all products</returns>
    async Task<IEnumerable<Product>> IProductRepository.GetAllProducts()
    {
       return  await _catalogContext.Products.Find(p => true).ToListAsync();
    }

    /// <summary>
    /// Retrieves all product types from the database
    /// </summary>
    /// <returns>Collection of all product types</returns>
    async Task<IEnumerable<ProductType>> ITypeRepository.GetAllTypes()
    {
        return await _catalogContext.Types.Find(p => true).ToListAsync();
    }

    /// <summary>
    /// Retrieves a specific product by its ID
    /// </summary>
    /// <param name="id">Product ID to search for</param>
    /// <returns>The matching product or null if not found</returns>
    async Task<Product> IProductRepository.GetProduct(string id)
    {
        return  await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Retrieves all products of a specific brand
    /// </summary>
    /// <param name="brandName">Brand name to filter by</param>
    /// <returns>Collection of products matching the brand name</returns>
    async Task<IEnumerable<Product>> IProductRepository.GetProductsByBrand(string brandName)
    {
        return await _catalogContext.Products.Find(p => p.Brands.Name.ToLower() == brandName.ToLower()).ToListAsync();
    }

    /// <summary>
    /// Retrieves all products with a specific name
    /// </summary>
    /// <param name="name">Product name to search for</param>
    /// <returns>Collection of products matching the name</returns>
    async Task<IEnumerable<Product>> IProductRepository.GetProductsByname(string name)
    {
        return await _catalogContext.Products.Find(p => p.Name.ToLower() == name.ToLower()).ToListAsync();
    }

    /// <summary>
    /// Updates an existing product in the database
    /// </summary>
    /// <param name="product">Product entity with updated values</param>
    /// <returns>True if update was successful, false otherwise</returns>
    async Task<bool> IProductRepository.UpdateProduct(Product product)
    {
        var updateResult =  await _catalogContext.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}
