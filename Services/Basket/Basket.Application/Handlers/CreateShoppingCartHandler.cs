namespace Basket.Application.Queries;

using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;
public class CreateShoppingCartHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
{
    private readonly IBasketRepository _basketRepository;

    public CreateShoppingCartHandler(IBasketRepository basketRepository)
    {
         _basketRepository = basketRepository;
    }
    public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = new ShoppingCart(request.UserName);
        shoppingCart.Items = request.Items;
        var createdShoppingCart = await _basketRepository.UpdateBasket(shoppingCart);
        return BasketMapper.Mapper.Map<ShoppingCartResponse>(createdShoppingCart);
    }
}