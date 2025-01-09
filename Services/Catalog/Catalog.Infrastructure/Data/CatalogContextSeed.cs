using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;
namespace Catalog.Infrastructure.Data;
/// <summary>
/// Static class for seeding initial product data into MongoDB collection
/// </summary>
public static class CatalogContextSeed
{
    /// <summary>
    /// Seeds product type data from JSON file into MongoDB collection if collection is empty
    /// </summary>
    /// <param name="mongoCollection">MongoDB collection to seed data into</param>
    public static void SeedData(IMongoCollection<Product> mongoCollection)
    {
        // Check if product collection is empty
        bool checkProducts = mongoCollection.Find(p => true).Any();

        // Only seed if no types exist
        if(!checkProducts)
        {
            // Get path to seed data JSON file
            string path = Path.Combine(Directory.GetCurrentDirectory(),"../Catalog.Infrastructure","Data", "SeedData", "products.json");
            
            // Read JSON file contents
            string productData = File.ReadAllText(path);
            
            // If file has data, deserialize and insert into MongoDB
            if(productData != null)
            {
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                mongoCollection.InsertManyAsync(products);
            }
        }
    }
}