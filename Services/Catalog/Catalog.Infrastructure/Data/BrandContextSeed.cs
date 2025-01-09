using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

/// <summary>
/// Static class for seeding initial brand data into MongoDB collection
/// </summary>
public static class BrandContextSeed 
{
    /// <summary>
    /// Seeds product brand data from JSON file into MongoDB collection if collection is empty
    /// </summary>
    /// <param name="mongoCollection">MongoDB collection to seed data into</param>
    public static void SeedData(IMongoCollection<ProductBrand> mongoCollection) {
        // Check if brands collection is empty
        bool checkBrands = mongoCollection.Find(p => true).Any();

        // Only seed if no brands exist
        if(!checkBrands) {
            // Get path to seed data JSON file
            string path = Path.Combine(Directory.GetCurrentDirectory(),"../Catalog.Infrastructure","Data", "SeedData", "brands.json");
            
            // Read JSON file contents
            string brandData = File.ReadAllText(path);
            
            // If file has data, deserialize and insert into MongoDB
            if(brandData is not null) {
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                mongoCollection.InsertManyAsync(brands);
            }
        }
    }
}
