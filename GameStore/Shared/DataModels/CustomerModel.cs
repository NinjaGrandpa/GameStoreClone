using System.ComponentModel.DataAnnotations;

namespace GameStore.Shared.DataModels;

public class CustomerModel
{
	public Guid Id { get; set; } = Guid.NewGuid();

	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;

	public string PostalCode { get; set; } = string.Empty;

	public string City { get; set; } = string.Empty;

	public string Country { get; set; } = string.Empty;
}