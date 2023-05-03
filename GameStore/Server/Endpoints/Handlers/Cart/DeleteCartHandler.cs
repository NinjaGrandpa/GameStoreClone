using GameStore.Server.Endpoints.Requests.Cart;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Cart;

public class DeleteCartHandler : IRequestHandler<DeleteCartRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteCartHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(DeleteCartRequest request, CancellationToken cancellationToken)
	{
		await _unitOfWork.CartRepository.RemoveCartFromDb(request.Id);
		await _unitOfWork.SaveAsync();

		return Results.Ok();
	}
}