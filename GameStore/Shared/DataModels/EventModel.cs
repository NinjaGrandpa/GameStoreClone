namespace GameStore.Shared.DataModels;

public class EventModel
{
	public Guid Id { get; set; } = Guid.NewGuid();

	public string EventName { get; set; } = string.Empty;

	public DateTime Date { get; set; } 

	public double Price { get; set; }

	public int MaxAvailableSeats { get; set; }

	public string ImageData { get; set; }

	public string Description { get; set; } = string.Empty;

	public string AgeRecommendation { get; set; } = string.Empty;

	public string Allergies { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;

	public string PostalCode { get; set; } = string.Empty;

	public string City { get; set; } = string.Empty;
}