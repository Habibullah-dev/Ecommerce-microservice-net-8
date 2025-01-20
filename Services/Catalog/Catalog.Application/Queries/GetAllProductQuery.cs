using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Queries;

public record GetAllProductQuery(CatalogueSpecParam param) : IRequest<Pagination<ProductResponse>>;