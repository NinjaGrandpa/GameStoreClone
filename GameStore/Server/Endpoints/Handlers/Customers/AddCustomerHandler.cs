using GameStore.Server.Endpoints.Requests.Customers;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Customers;

public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public AddCustomerHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
	{
		request.CustomerDto.Id = Guid.NewGuid();
		await _unitOfWork.CustomerRepository.AddCustomerToDb(request.CustomerDto);
		await _unitOfWork.SaveAsync();

		return Results.Ok(request.CustomerDto);
	}
}