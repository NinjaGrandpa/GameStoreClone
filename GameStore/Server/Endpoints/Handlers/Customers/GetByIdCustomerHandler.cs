using GameStore.Server.Endpoints.Requests.Customers;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Customers;

public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetByIdCustomerHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(GetByIdCustomerRequest request, CancellationToken cancellationToken)
	{
		var customer = await _unitOfWork.CustomerRepository.FetchCustomerByIdFromDb(request.Id);

		if (customer is null)
		{
			return Results.NotFound(request.Id);
		}

		return Results.Ok(customer);
	}
}