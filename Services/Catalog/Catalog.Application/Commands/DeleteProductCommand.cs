using MediatR;

namespace Catalog.Application.Commands;

public record DeleteProductCommand(string id) : IRequest<bool>;