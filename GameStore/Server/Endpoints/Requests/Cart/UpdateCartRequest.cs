using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Cart;

public class UpdateCartRequest : IHttpRequest
{
	public CartDto Cart { get; set; }
}