namespace GameStore.Server.Endpoints.Requests.Customers;

public class DeleteCustomerRequest : IHttpRequest
{
	public Guid Id { get; set; }
}