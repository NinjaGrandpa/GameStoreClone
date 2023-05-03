using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Shared.DataModels.Products;

public class CartDetailsModel
{
	public Guid Id { get; set; }


	[ForeignKey("Cart")]
	public Guid CartId { get; set; }
	public CartModel Cart { get; set; }


	[ForeignKey("Product")]
	public Guid ProductId { get; set; }
	public ProductModel Product { get; set; }


	public int Quantity { get; set; }


	[Precision(38, 2)]
	public decimal OrderDetailsCost { get; set; }
}