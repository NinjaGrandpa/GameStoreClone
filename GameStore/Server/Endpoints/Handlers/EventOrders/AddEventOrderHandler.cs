using GameStore.Server.Endpoints.Requests.EventOrders;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.EventOrders;

public class AddEventOrderHandler : IRequestHandler<AddEventOrderRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddEventOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(AddEventOrderRequest request, CancellationToken cancellationToken)
    {
       var eventOrder = await _unitOfWork.EventOrderRepository.AddEventOrderToDb(request.EventOrderDto);
        await _unitOfWork.SaveAsync();
        return Results.Ok(eventOrder);
    }
}