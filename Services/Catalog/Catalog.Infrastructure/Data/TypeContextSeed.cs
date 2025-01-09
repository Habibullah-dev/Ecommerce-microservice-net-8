using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

/// <summary>
/// Static class for seeding initial type data into MongoDB collection
/// </summary>
public static class TypeContextSeed
{
    /// <summary>
    /// Seeds product type data from JSON file into MongoDB collection if collection is empty
    /// </summary>
    /// <param name="mongoCollection">MongoDB collection to seed data into</param>
    public static void SeedData(IMongoCollection<ProductType> mongoCollection)
    {
        // Check if types collection is empty
        bool checkTypes = mongoCollection.Find(p => true).Any();

        // Only seed if no types exist
        if(!checkTypes)
        {
            // Get path to seed data JSON file
            string path = Path.Combine(Directory.GetCurrentDirectory(),"../Catalog.Infrastructure","Data", "SeedData", "types.json");
            
            // Read JSON file contents
            string typeData = File.ReadAllText(path);
            
            // If file has data, deserialize and insert into MongoDB
            if(typeData != null)
            {
                var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                mongoCollection.InsertManyAsync(types);
            }
        }
    }
}