using Catalog.Application.Commands;
using Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Handlers;


public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProduct(request.id);
      
        return product == null ? false : await _productRepository.DeleteProduct(product);
    }
}   