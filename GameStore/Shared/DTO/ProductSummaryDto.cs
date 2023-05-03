using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DTO;

public class ProductSummaryDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Manufacturer { get; set; }

    public string? Description { get; set; }

    public string? ImageData { get; set; } = string.Empty;

    [Precision(38, 2)]
    public decimal UnitPrice { get; set; }

    public int AmountInStock { get; set; }

    public Guid SpecificationGroupId { get; set; }

    public string? Title { get; set; } = string.Empty;

    public List<SpecificationItemDto>? SpecificationItems { get; set; } = new List<SpecificationItemDto>();
}