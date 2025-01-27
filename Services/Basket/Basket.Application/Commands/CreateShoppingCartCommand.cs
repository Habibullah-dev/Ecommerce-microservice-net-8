using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands
{
    public record CreateShoppingCartCommand(string UserName, List<ShoppingCartItem> Items) : IRequest<ShoppingCartResponse>;
}