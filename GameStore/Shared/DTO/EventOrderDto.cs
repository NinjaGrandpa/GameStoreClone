using System.ComponentModel.DataAnnotations;
namespace GameStore.Shared.DTO;
public class EventOrderDto
{
	public Guid Id { get; set; }
	public Guid CustomerId { get; set; } 
	public Guid EventId { get; set; }
	public DateTime CreatedDate { get; set; }

	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

    public string Allergies { get; set; } = string.Empty;

	public int AmountOfSeats { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
}