using System.ComponentModel.DataAnnotations.Schema;
using GameStore.Shared.DataModels.Enums;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DataModels.Products;

public class ProductOrderModel
{
	public Guid Id { get; set; } = Guid.NewGuid();


	[ForeignKey("Customer")] 
	public Guid CustomerId { get; set; }
	public CustomerModel Customer { get; set; }


	public ICollection<ProductOrderDetailsModel> OrderDetails { get; set; } = new List<ProductOrderDetailsModel>();


	public DateTime CreatedDate { get; set; }


	public OrderStatus Status { get; set; }


	[Precision(38, 2)]
	public decimal OrderCost { get; set; }


	public byte[]? RowVersion { get; set; }
}