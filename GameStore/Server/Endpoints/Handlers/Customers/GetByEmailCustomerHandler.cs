using GameStore.Server.Endpoints.Requests.Customers;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Customers;

public class GetByEmailCustomerHandler : IRequestHandler<GetByEmailCustomerRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByEmailCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(GetByEmailCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.CustomerRepository.FetchCustomerByEmailFromDb(request.Email);

        if (customer is null)
        {
            return Results.NotFound(request.Email);
        }

        return Results.Ok(customer);
    }
}