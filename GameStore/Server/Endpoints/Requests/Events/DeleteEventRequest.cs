namespace GameStore.Server.Endpoints.Requests.Events;

public class DeleteEventRequest : IHttpRequest
{
    public Guid Id { get; set; }

}