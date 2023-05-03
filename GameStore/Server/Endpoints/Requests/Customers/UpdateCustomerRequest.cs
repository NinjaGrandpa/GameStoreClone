using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Customers;

public class UpdateCustomerRequest : IHttpRequest
{
	public CustomerDto CustomerDto { get; set; }
}