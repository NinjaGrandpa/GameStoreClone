using GameStore.Server.Endpoints.Requests.Customers;

namespace GameStore.Server.Extensions.EndpointsGrouped;

public static class CustomerGroupBuilderExtensions
{
	public static RouteGroupBuilder MapCustomerGroup(this RouteGroupBuilder builder)
	{
		builder.MediateGet<GetAllCustomersRequest>("/all");
		builder.MediateGet<GetByIdCustomerRequest>("/{id}");
        builder.MediateGet<GetByEmailCustomerRequest>("/email/{email}");
		builder.MediatePost<AddCustomerRequest>("/");
		builder.MediatePut<UpdateCustomerRequest>("/");
		builder.MediateDelete<DeleteCustomerRequest>("/{id}");
		return builder;
	}
}