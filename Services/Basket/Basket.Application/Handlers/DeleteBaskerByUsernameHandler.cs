using Basket.Application.Commands;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class DeleteBasketByUsernameHandler : IRequestHandler<DeleteBasketByUsernameCommand, Unit>
{
    private readonly IBasketRepository _repository;

    public DeleteBasketByUsernameHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteBasketByUsernameCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteBasket(request.username);
        return Unit.Value;
    }
}