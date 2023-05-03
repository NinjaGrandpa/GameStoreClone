using GameStore.Shared.DTO;

namespace GameStore.Shared.Services.Interfaces;

public interface IEventOrderRepository
{
	Task<EventOrderDto> AddEventOrderToDb(EventOrderDto eventOrder);

	Task RemoveEventOrderFromDb(Guid id);

	Task<IEnumerable<EventOrderDto>> FetchAllEventOrdersFromDb();

	Task<EventOrderDto> FetchEventOrderByIdFromDb(Guid id);
}