using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.DTO;

public class CustomerDto
{
	public Guid Id { get; set; }


	[Required, StringLength(50)]
	public string FirstName { get; set; } = string.Empty;


	[Required, StringLength(50)]
	public string LastName { get; set; } = string.Empty;


	[Phone]
	public string PhoneNumber { get; set; } = string.Empty;


	[Required, EmailAddress]
	public string Email { get; set; } = string.Empty;


	[StringLength(50)]
	public string Address { get; set; } = string.Empty;


	[StringLength(50)]
	public string PostalCode { get; set; } = string.Empty;


	[StringLength(50)]
	public string City { get; set; } = string.Empty;


	[StringLength(50)]
	public string Country { get; set; } = string.Empty;
}

