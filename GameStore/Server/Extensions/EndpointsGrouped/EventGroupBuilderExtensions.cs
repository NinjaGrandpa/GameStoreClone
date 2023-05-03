using GameStore.Server.Endpoints.Requests.Events;

namespace GameStore.Server.Extensions.EndpointsGrouped
{
    public static class EventGroupBuilderExtensions
    {
        public static RouteGroupBuilder MapEventGroup(this RouteGroupBuilder builder)
        {
            builder.MediateGet<GetAllEventsRequest>("/all");
            builder.MediateGet<GetByIdEventRequest>("/{id}");
            builder.MediatePost<AddEventRequest>("/");
            builder.MediatePut<UpdateEventRequest>("/");
            builder.MediateDelete<DeleteEventRequest>("/{id}");
            return builder;
        }
    }
}
