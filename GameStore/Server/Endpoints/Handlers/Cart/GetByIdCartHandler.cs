using GameStore.Server.Endpoints.Requests.Cart;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Cart;

public class GetByIdCartHandler : IRequestHandler<GetByIdCartRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetByIdCartHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(GetByIdCartRequest request, CancellationToken cancellationToken)
	{
		var cart = await _unitOfWork.CartRepository.FetchCartById(request.Id);

		if (cart.Id == Guid.Empty) return Results.NotFound();

		return Results.Ok(cart);
	}
}