using GameStore.Shared.DTO;

namespace GameStore.Shared.Services.Interfaces;

public interface IEventRepository
{
	Task AddEventToDb(EventDto theEvent);

	Task RemoveEventFromDb(Guid id);

	Task UpdateEventInDb(EventDto theEvent);

	Task<IEnumerable<EventDto>> FetchAllEventsFromDb();

	Task<EventDto> FetchEventByIdFromDb(Guid id);
}