using GameStore.Server.Endpoints.Requests.EventOrders;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.EventOrders;

public class GetByIdEventOrderHandler : IRequestHandler<GetByIdEventOrderRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdEventOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(GetByIdEventOrderRequest request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.EventOrderRepository.FetchEventOrderByIdFromDb(request.Id);
        if (order is null)
        {
            return Results.NotFound(request.Id);
        }
        return Results.Ok(order);
    }
}