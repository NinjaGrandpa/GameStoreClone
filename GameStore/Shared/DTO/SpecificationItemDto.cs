namespace GameStore.Shared.DTO;

public class SpecificationItemDto
{
    public Guid Id { get; set; }

    public string? InformationType { get; set; } = string.Empty;

    public string? InformationValue { get; set; } = string.Empty;
}