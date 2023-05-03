using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Cart;

public class AddCartRequest : IHttpRequest
{
	public CartDto Cart { get; set; }
}