using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DTO;

public class CartDetailsDto
{
	public Guid Id { get; set; }


	public Guid CartId { get; set; }


	public Guid ProductId { get; set; }


	public int Quantity { get; set; }


	[Precision(38, 2)]
	public decimal OrderDetailsCost { get; set; }
}