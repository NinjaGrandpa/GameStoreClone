using GameStore.Server.Endpoints.Requests.Customers;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Customers;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateCustomerHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
	{
		await _unitOfWork.CustomerRepository.UpdateCustomerInDb(request.CustomerDto);
		await _unitOfWork.SaveAsync();
		return Results.Ok(request.CustomerDto);
	}
}