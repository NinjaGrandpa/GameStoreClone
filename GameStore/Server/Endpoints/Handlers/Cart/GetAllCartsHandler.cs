using GameStore.Server.Endpoints.Requests.Cart;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Cart;

public class GetAllCartsHandler : IRequestHandler<GetAllCartsRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllCartsHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(GetAllCartsRequest request, CancellationToken cancellationToken)
	{
		var carts = await _unitOfWork.CartRepository.FetchAllCartsFromDb();

		return Results.Ok(carts);
	}
}