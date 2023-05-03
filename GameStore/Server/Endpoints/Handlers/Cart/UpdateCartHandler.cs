using GameStore.Server.Endpoints.Requests.Cart;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Cart;

public class UpdateCartHandler : IRequestHandler<UpdateCartRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateCartHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(UpdateCartRequest request, CancellationToken cancellationToken)
	{
		await _unitOfWork.CartRepository.UpdateCartInDb(request.Cart);
		await _unitOfWork.SaveAsync();

		return Results.Ok();
	}
}