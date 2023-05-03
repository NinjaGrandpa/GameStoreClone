using GameStore.Server.Endpoints.Requests.EventOrders;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.EventOrders;

public class DeleteEventOrderHandler : IRequestHandler<DeleteEventOrderRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEventOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(DeleteEventOrderRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.EventOrderRepository.RemoveEventOrderFromDb(request.Id);
        await _unitOfWork.SaveAsync();
        return Results.Ok(request.Id);
    }
}