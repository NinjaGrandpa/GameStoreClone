using GameStore.Shared.DTO;

namespace GameStore.Shared.Services.Interfaces;

public interface IProductRepository
{
    Task AddProductToDb(ProductDto product);

    Task RemoveProductFromDb(Guid id);

    Task UpdateProductInDb(ProductDto product);

    Task<IEnumerable<ProductDto>> FetchAllProductsFromDb();

    Task<ProductDto> FetchProductByIdFromDb(Guid id);
}