using GameStore.Shared.DataModels.Products;

namespace GameStore.Shared.DTO;

public class SpecificationGroupDto
{
	public Guid Id { get; set; }

	public string? Title { get; set; } = string.Empty;

	public List<SpecificationItemDto>? SpecificationItems { get; set; } = new List<SpecificationItemDto>();
}