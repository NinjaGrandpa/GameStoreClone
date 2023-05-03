using System.ComponentModel.DataAnnotations;

namespace GameStore.Server.Endpoints.Requests.Customers;

public class GetByEmailCustomerRequest : IHttpRequest
{
    [EmailAddress]
    public string Email { get; set; }
}