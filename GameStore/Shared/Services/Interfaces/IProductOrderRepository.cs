using GameStore.Shared.DTO;

namespace GameStore.Shared.Services.Interfaces
{
    public interface IProductOrderRepository
    {
        Task<ProductOrderDto> AddProductOrderToDb(ProductOrderDto dto);
        Task<IEnumerable<ProductOrderDto>> FetchAllProductOrdersFromDbTable();
        Task RemoveProductOrderFromDb(Guid id);
        Task UpdateProductOrderInTable(ProductOrderDto productOrderDto);
        Task<ProductOrderDto> FetchProductOrderById(Guid id);
    }
}
