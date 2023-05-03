using GameStore.Server.Endpoints.Requests.Customers;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Customers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteCustomerHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
	{
		await _unitOfWork.CustomerRepository.RemoveCustomerFromDb(request.Id);
		await _unitOfWork.SaveAsync();

		return Results.Ok(request.Id);
	}
}