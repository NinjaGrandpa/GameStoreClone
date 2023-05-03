namespace GameStore.Server.Endpoints.Requests.Cart;

public class GetByIdCartRequest : IHttpRequest
{
	public Guid Id { get; set; }
}