using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;

namespace  Catalog.Application.Commands;


public class UpdateProductCommand : IRequest<bool>
{
   public string Id { get; set; } = null!;
   public string Name {get;set;} = string.Empty;
   public string Summary { get; set; } = string.Empty;
   public string Description { get; set; } = string.Empty;
   public string ImageFile {get;set;} = string.Empty;
   public ProductBrand? Brand {get;set; } 
   public ProductType? Type {get;set;}
   public decimal? Price {get;set;}
}