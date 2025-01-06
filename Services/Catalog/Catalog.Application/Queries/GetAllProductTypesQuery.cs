using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public record GetAllProductTypesQuery : IRequest<IList<ProductTypeResponse>>;