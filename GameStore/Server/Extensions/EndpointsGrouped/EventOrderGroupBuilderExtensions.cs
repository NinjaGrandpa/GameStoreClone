using GameStore.Server.Endpoints.Requests.EventOrders;
using GameStore.Server.Endpoints.Requests.Events;

namespace GameStore.Server.Extensions.EndpointsGrouped;

public static class EventOrderGroupBuilderExtensions
{
    public static RouteGroupBuilder MapEventOrderGroup(this RouteGroupBuilder builder)
    {
        builder.MediateGet<GetAllEventOrdersRequest>("/all");
        builder.MediateGet<GetByIdEventOrderRequest>("/{id}");
        builder.MediatePost<AddEventOrderRequest>("/");
        builder.MediateDelete<DeleteEventOrderRequest>("/{id}");
        return builder;
    }
}