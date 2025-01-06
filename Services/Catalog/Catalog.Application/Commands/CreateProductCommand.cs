using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Commands;

public class CreateProductCommand : IRequest<ProductResponse>
{
   public string Name {get;set;} = string.Empty;
   public string Summary { get; set; } = string.Empty;
   public string Description { get; set; } = string.Empty;
   public string ImageFile {get;set;} = string.Empty;
   public ProductBrand Brand {get;set; } = null!;
   public ProductType Type {get;set;} = null!;
   public decimal Price {get;set;}
}
























