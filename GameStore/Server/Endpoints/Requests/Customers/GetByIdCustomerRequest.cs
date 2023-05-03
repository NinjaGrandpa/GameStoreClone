namespace GameStore.Server.Endpoints.Requests.Customers;

public class GetByIdCustomerRequest : IHttpRequest
{
	public Guid Id { get; set; }
}