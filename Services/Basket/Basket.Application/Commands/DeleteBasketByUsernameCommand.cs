using MediatR;

namespace Basket.Application.Commands;

public record DeleteBasketByUsernameCommand(string username) : IRequest<Unit>;