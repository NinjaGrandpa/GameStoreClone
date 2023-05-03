using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Events
{
    public class AddEventRequest : IHttpRequest
    {
        public EventDto EventDto { get; set; }

    }
}
