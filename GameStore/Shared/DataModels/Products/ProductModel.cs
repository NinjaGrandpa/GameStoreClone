using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DataModels.Products
{
	public class ProductModel
	{
		public Guid Id { get; set; } = Guid.NewGuid();


		public ICollection<SpecificationGroupModel>? SpecificationGroups { get; set; } = new List<SpecificationGroupModel>();


		public string? Name { get; set; } = string.Empty;


		public string? Manufacturer { get; set; } = string.Empty;


		public string? Description { get; set; } = string.Empty;


		public string? ImageData { get; set; } = string.Empty;


		[Precision(38, 2)]
		public decimal UnitPrice { get; set; }


		public int AmountInStock { get; set; }
	}
}
