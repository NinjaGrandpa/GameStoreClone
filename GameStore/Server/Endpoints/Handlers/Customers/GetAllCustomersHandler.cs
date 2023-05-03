using GameStore.Server.Endpoints.Requests.Customers;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Customers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersRequest, IResult>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllCustomersHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
	{
		return Results.Ok(await _unitOfWork.CustomerRepository.FetchAllCustomersFromDb());
	}
}