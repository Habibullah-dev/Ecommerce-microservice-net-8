using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Product : BaseEntity
{
   [BsonElement("Name")]
   public string Name {get;set;} = string.Empty;
   public string Summary { get; set; } = string.Empty;
   public string Description { get; set; } = string.Empty;
   public string ImageFile {get;set;} = string.Empty;
   public ProductBrand Brand {get;set; } = null!;
   public ProductType Type {get;set;} = null!;
   [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
   public decimal Price {get;set;}
}