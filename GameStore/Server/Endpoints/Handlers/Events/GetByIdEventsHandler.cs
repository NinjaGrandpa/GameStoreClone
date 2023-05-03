using GameStore.Server.Endpoints.Requests;
using GameStore.Server.Endpoints.Requests.Events;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Events;

public class GetByIdEventsHandler : IRequestHandler<GetByIdEventRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdEventsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(GetByIdEventRequest eventRequest, CancellationToken cancellationToken)
    {
        var theEvent = await _unitOfWork.EventRepository.FetchEventByIdFromDb(eventRequest.Id);
        if (theEvent is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(theEvent);
    }
}