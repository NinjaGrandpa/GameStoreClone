using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DTO;

public class CartDto
{
	public Guid Id { get; set; }


	public Guid CustomerId { get; set; }


	public List<CartDetailsDto> CartDetails { get; set; } = new List<CartDetailsDto>();


	[Precision(38, 2)]
	public decimal CartCost { get; set; }
}