using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controller;

public class BasketController : ApiController
{
    public BasketController(ISender sender) : base(sender){

    }
    [HttpGet]
    [Route("[action]/{username}",Name = "GetBasketByUserName")]
    [ProducesResponseType(typeof(ShoppingCartResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShoppingCartResponse>> GetBasket(string username)
    {
        var basket = await _sender.Send(new GetBasketByUsernameQuery(username));
        return basket is null ? NotFound() : Ok(basket);
    }
    // [HttpPost("CreateBasket")]
    // [ProducesResponseType(typeof(ShoppingCartResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand basket)
    // {
    //     var updatedBasket = await _sender.Send(new UpdateBasketCommand(basket));
    //     return updatedBasket is null ? NotFound() : Ok(updatedBasket);
    // }


}