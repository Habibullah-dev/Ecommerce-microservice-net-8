using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProduct(request.Id);
        if (product == null)
        {
            throw new ArgumentException("Product not found, invalid Id");
        }

        var updatedProduct = new Product
        {
            Id = request.Id,
            Name =  string.IsNullOrWhiteSpace(request.Name) ? product.Name : request.Name,
            Description = string.IsNullOrWhiteSpace(request.Description) ? product.Description : request.Description,
            Price = (decimal) (request.Price == null ? product.Price : request.Price),
            ImageFile = string.IsNullOrWhiteSpace(request.ImageFile) ? product.ImageFile : request.ImageFile,
            Brands = request.Brand is null  ? product.Brands : request.Brand,
            Types = request.Type is null ? product.Types : request.Type
            
        };
        return await _productRepository.UpdateProduct(updatedProduct);
        
    }
}