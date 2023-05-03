using System.ComponentModel.DataAnnotations;

namespace GameStore.Shared.DTO;

public class EventDto
{
	public Guid Id { get; set; }

	public string EventName { get; set; } = string.Empty;

	public DateTime Date { get; set; } = DateTime.UtcNow;


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
