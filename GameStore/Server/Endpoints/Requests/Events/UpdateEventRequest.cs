using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Events
{
    public class UpdateEventRequest : IHttpRequest
    {
        public EventDto EventDto { get; set; }

    }
}
