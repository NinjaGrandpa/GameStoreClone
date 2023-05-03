namespace GameStore.Shared.DataModels.Products
{
    public class SpecificationGroupModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Title { get; set; } = string.Empty;

        public ICollection<SpecificationItemModel>? SpecificationItems { get; set; } = new List<SpecificationItemModel>();
    }
}
