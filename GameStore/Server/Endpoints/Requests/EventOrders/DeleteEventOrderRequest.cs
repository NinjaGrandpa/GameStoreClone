namespace GameStore.Server.Endpoints.Requests.EventOrders;

public class DeleteEventOrderRequest : IHttpRequest
{
    public Guid Id { get; set; }

}