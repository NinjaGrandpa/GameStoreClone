using GameStore.Server.Endpoints.Requests.Events;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Events;

public class AddEventHandler : IRequestHandler<AddEventRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddEventHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(AddEventRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.EventRepository.AddEventToDb(request.EventDto);
        await _unitOfWork.SaveAsync();
        return Results.Ok(request.EventDto);
    }
}