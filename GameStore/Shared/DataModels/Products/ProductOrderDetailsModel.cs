using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Shared.DataModels.Products;

public class ProductOrderDetailsModel
{
	public Guid Id { get; set; } = Guid.NewGuid();


	[ForeignKey("ProductOrder")]
	public Guid ProductOrderId { get; set; }
	public ProductOrderModel ProductOrder { get; set; }


	[ForeignKey("Product")]
	public Guid ProductId { get; set; }
	public ProductModel Product { get; set; }


	public int Quantity { get; set; }


	[Precision(38, 2)]
	public decimal OrderDetailsCost { get; set; }
}