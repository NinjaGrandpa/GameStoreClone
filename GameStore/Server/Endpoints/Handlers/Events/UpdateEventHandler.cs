using GameStore.Server.Endpoints.Requests.Events;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Events;

public class UpdateEventHandler : IRequestHandler<UpdateEventRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEventHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(UpdateEventRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.EventRepository.UpdateEventInDb(request.EventDto);
        await _unitOfWork.SaveAsync();
        return Results.Ok(request.EventDto);
    }
}