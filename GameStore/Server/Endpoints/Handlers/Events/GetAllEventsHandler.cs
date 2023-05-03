using GameStore.Server.Endpoints.Requests.Events;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Events
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsRequest, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEventsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(GetAllEventsRequest request, CancellationToken cancellationToken)
        {
            var allEvents = await _unitOfWork.EventRepository.FetchAllEventsFromDb();
            return Results.Ok(allEvents);
        }

    }
}
