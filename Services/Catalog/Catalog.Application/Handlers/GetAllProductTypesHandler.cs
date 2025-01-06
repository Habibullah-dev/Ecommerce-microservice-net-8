using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, IList<ProductTypeResponse>>
{
    private readonly ITypeRepository _productTypeRepository;

    public GetAllProductTypesHandler(ITypeRepository productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }
    public async Task<IList<ProductTypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var productTypesList = await _productTypeRepository.GetAllTypes();
        var productTypeResponseList = Productmapper.Mapper.Map<IList<ProductTypeResponse>>(productTypesList);
        return productTypeResponseList;
    }
}
