namespace GameStore.Server.Endpoints.Requests.Cart;

public class DeleteCartRequest : IHttpRequest
{
	public Guid Id { get; set; }
}