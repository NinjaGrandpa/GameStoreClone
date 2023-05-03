namespace GameStore.Server.Endpoints.Requests.EventOrders;

public class GetByIdEventOrderRequest : IHttpRequest
{
    public Guid Id { get; set; }

}