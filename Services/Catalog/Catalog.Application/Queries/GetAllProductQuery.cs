using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public record GetAllProductQuery : IRequest<IList<ProductResponse>>;