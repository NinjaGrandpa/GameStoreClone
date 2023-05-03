namespace GameStore.Server.Endpoints.Requests.Events;

public class GetByIdEventRequest : IHttpRequest
{
    public Guid Id { get; set; }

}