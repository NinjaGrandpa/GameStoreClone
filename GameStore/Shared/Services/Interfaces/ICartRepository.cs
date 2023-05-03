using GameStore.Shared.DTO;

namespace GameStore.Shared.Services.Interfaces;

public interface ICartRepository
{
	Task<CartDto> AddCartToDb(CartDto cartDto);
	Task<IEnumerable<CartDto>> FetchAllCartsFromDb();
	Task RemoveCartFromDb(Guid id);
	Task UpdateCartInDb(CartDto dto);
	Task<CartDto> FetchCartById(Guid id);
}