using GameStore.Server.Endpoints.Requests.Cart;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Cart;

public class AddCartHandler : IRequestHandler<AddCartRequest,IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public AddCartHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(AddCartRequest request, CancellationToken cancellationToken)
	{
		var cart = await _unitOfWork.CartRepository.AddCartToDb(request.Cart);
		await _unitOfWork.SaveAsync();
		
		return Results.Ok(cart);
	}
}