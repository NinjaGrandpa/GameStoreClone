using GameStore.Server.Endpoints.Requests.Cart;

namespace GameStore.Server.Extensions.EndpointsGrouped;

public static class CartGroupBuilderExtensions
{
	public static RouteGroupBuilder MapCartGroup(this RouteGroupBuilder builder)
	{
		builder.MediateGet<GetAllCartsRequest>("/all");
		builder.MediateGet<GetByIdCartRequest>("/{id}");
		builder.MediatePost<AddCartRequest>("/");
		builder.MediatePut<UpdateCartRequest>("/");
		builder.MediateDelete<DeleteCartRequest>("/{id}");
		return builder;
	}
}