using GameStore.Shared.DTO;
using MediatR;

namespace GameStore.Server.Endpoints.Requests.EventOrders;

public class AddEventOrderRequest : IHttpRequest
{
    public EventOrderDto EventOrderDto { get; set; }
}