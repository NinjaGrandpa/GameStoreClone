using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Customers;

public class AddCustomerRequest : IHttpRequest
{
	public CustomerDto CustomerDto { get; set; }
}