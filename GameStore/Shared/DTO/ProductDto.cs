using GameStore.Shared.DataModels.Products;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Manufacturer { get; set; }

        public string? Description { get; set; }

        public string? ImageData { get; set; } = string.Empty;

        [Precision(38, 2)]
        public decimal UnitPrice { get; set; }

        public int AmountInStock { get; set; }

        public List<SpecificationGroupDto>? SpecificationGroups { get; set; } = new List<SpecificationGroupDto>();
    }
}
