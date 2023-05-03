namespace GameStore.Shared.DataModels.Products
{
    public class SpecificationItemModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? InformationType { get; set; } = string.Empty;

        public string? InformationValue { get; set; } = string.Empty;
    }
}
