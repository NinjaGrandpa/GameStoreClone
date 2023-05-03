using GameStore.Server.Endpoints.Requests.Events;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Events;

public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, IResult>
{
    private readonly IUnitOfWork _umiOfWork;

    public DeleteEventHandler(IUnitOfWork umiOfWork)
    {
        _umiOfWork = umiOfWork;
    }

    public async Task<IResult> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
    {
        await _umiOfWork.EventRepository.RemoveEventFromDb(request.Id);
        await _umiOfWork.SaveAsync();
        return Results.Ok(request.Id);
    }
}