
using GameStore.DataAccess.Contexts;
using GameStore.Shared.DataModels;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Service.Services.Repositories;

public class EventRepository : IEventRepository
{
	#region Fields & CTOR

	private readonly GameStoreContext _dbContext;

	public EventRepository(GameStoreContext dbContext)
	{
		_dbContext = dbContext;
	}
	#endregion

	#region CRUD Operations
	public async Task AddEventToDb(EventDto theEvent)
	{
		theEvent.Id = Guid.NewGuid();
		await _dbContext.Events!.AddAsync(ConvertToModel(theEvent));
	}

	public async Task RemoveEventFromDb(Guid id)
	{
		var theEvent = await _dbContext.Events!.FindAsync(id);

		if (theEvent is null) return;

		_dbContext.Events.Remove(theEvent);
	}

	public async Task UpdateEventInDb(EventDto theEvent)
	{
		var eventToUpdate = await _dbContext.Events!.FindAsync(theEvent.Id);

		if (eventToUpdate is null)
		{
			Console.WriteLine("The event was not found");
			return;
		}

		eventToUpdate.EventName = theEvent.EventName;
		eventToUpdate.Date = theEvent.Date;
		eventToUpdate.Price = theEvent.Price;
		eventToUpdate.MaxAvailableSeats = theEvent.MaxAvailableSeats;
		eventToUpdate.ImageData = theEvent.ImageData;
		eventToUpdate.Description = theEvent.Description;
		eventToUpdate.AgeRecommendation = theEvent.AgeRecommendation;
		eventToUpdate.Allergies = theEvent.Allergies;
		eventToUpdate.Address = theEvent.Address;
		eventToUpdate.PostalCode = theEvent.PostalCode;
		eventToUpdate.City = theEvent.City;

		_dbContext.Events.Update(eventToUpdate);
	}

	public async Task<IEnumerable<EventDto>> FetchAllEventsFromDb()
	{
		var eventsToReturn = await _dbContext.Events!.ToListAsync();

		if (!eventsToReturn.Any()) return new List<EventDto>();

		return eventsToReturn.Select(ConvertToDto);
	}

	public async Task<EventDto> FetchEventByIdFromDb(Guid id)
	{
		var theEvent = await _dbContext.Events!.FindAsync(id);

		if (theEvent is null) return new EventDto();

		return ConvertToDto(theEvent);
	}

	private EventModel ConvertToModel(EventDto eventDto)
	{
		return new EventModel()
		{
			Id = eventDto.Id,
			EventName = eventDto.EventName,
			Date = eventDto.Date,
			Price = eventDto.Price,
			MaxAvailableSeats = eventDto.MaxAvailableSeats,
			ImageData = eventDto.ImageData,
			Description = eventDto.Description,
			AgeRecommendation = eventDto.AgeRecommendation,
			Allergies = eventDto.Allergies,
			Address = eventDto.Address,
			PostalCode = eventDto.PostalCode,
			City = eventDto.City
		};
	}

	private EventDto ConvertToDto(EventModel eventModel)
	{
		return new EventDto()
		{
			Id = eventModel.Id,
			EventName = eventModel.EventName,
			Description = eventModel.Description,
			MaxAvailableSeats = eventModel.MaxAvailableSeats,
			ImageData = eventModel.ImageData,
			Address = eventModel.Address,
			PostalCode = eventModel.PostalCode,
			City = eventModel.City,
			Date = eventModel.Date,
			AgeRecommendation = eventModel.AgeRecommendation,
			Allergies = eventModel.Allergies,
			Price = eventModel.Price
		};
	}
	#endregion
}