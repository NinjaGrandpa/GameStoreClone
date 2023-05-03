using GameStore.Server.Endpoints.Requests.EventOrders;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.EventOrders;

public class GetAllEventOrdersHandler : IRequestHandler<GetAllEventOrdersRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEventOrdersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(GetAllEventOrdersRequest request, CancellationToken cancellationToken)
    {
        var allEventsOrders = await _unitOfWork.EventOrderRepository.FetchAllEventOrdersFromDb();
        return Results.Ok(allEventsOrders);
    }
}