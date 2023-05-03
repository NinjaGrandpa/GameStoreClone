using GameStore.DataAccess.Contexts;
using GameStore.Shared.DataModels;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Service.Services.Repositories;

public class EventOrderRepository : IEventOrderRepository
{
	#region Fields & CTOR

	private readonly GameStoreContext _dbContext;

	public EventOrderRepository(GameStoreContext dbContext)
	{
		_dbContext = dbContext;
	}

	#endregion

	public async Task<EventOrderDto> AddEventOrderToDb(EventOrderDto eventOrder)
	{
		eventOrder.Id = Guid.NewGuid();
        eventOrder.CreatedDate = DateTime.UtcNow;
		var entity = await _dbContext.EventOrder!.AddAsync(ConvertToModel(eventOrder));
        return ConvertToDto(entity.Entity);
    }

	public async Task RemoveEventOrderFromDb(Guid id)
	{
		var eventOrderToRemove = await _dbContext.EventOrder!.FindAsync(id);

		if (eventOrderToRemove is null) return;

		_dbContext.EventOrder.Remove(eventOrderToRemove);
	}

	public async Task<IEnumerable<EventOrderDto>> FetchAllEventOrdersFromDb()
	{
		var allEventOrders = await _dbContext.EventOrder!.ToListAsync();

		if (!allEventOrders.Any()) return new List<EventOrderDto>();

		return allEventOrders.Select(ConvertToDto);
	}

	public async Task<EventOrderDto> FetchEventOrderByIdFromDb(Guid id)
	{
		var eventOrder = await _dbContext.EventOrder!.FindAsync(id);

		if (eventOrder is null) return new EventOrderDto();

		return ConvertToDto(eventOrder);
	}

	private EventOrderDto ConvertToDto(EventOrderModel model)
	{
		return new EventOrderDto()
		{
			Id = model.Id,
			CustomerId = model.CustomerId,
			EventId = model.EventId,
			CreatedDate = model.CreatedDate,
			FirstName = model.FirstName,
			LastName = model.LastName,
			Email = model.Email,
			PhoneNumber = model.PhoneNumber,
			Allergies = model.Allergies,
			AmountOfSeats = model.AmountOfSeats
		};
	}

	private EventOrderModel ConvertToModel(EventOrderDto dto)
	{
		return new EventOrderModel()
		{
			Id = dto.Id,
			CustomerId = dto.CustomerId,
			EventId = dto.EventId,
			CreatedDate = dto.CreatedDate,
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			Email = dto.Email,
			PhoneNumber = dto.PhoneNumber,
			Allergies = dto.Allergies,
			AmountOfSeats = dto.AmountOfSeats
		};
	}
}