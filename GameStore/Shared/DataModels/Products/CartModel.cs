using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Shared.DataModels.Products;

public class CartModel
{
	public Guid Id { get; set; }


	[ForeignKey("Customer")]
	public Guid CustomerId { get; set; }
	public CustomerModel Customer { get; set; }


	public ICollection<CartDetailsModel> CartDetails { get; set; } = new List<CartDetailsModel>();


	[Precision(38, 2)]
	public decimal CartCost { get; set; }
}