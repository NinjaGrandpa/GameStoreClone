using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Shared.DataModels;

public class EventOrderModel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();


    [ForeignKey("Customer")] 
    public Guid CustomerId { get; set; } 
    public CustomerModel? Customer { get; set; }


    [ForeignKey("Event")] 
    public Guid EventId { get; set; } 
    public EventModel? Event { get; set; }


    public DateTime CreatedDate { get; set; }

    
    public string FirstName { get; set; } = string.Empty;

    
    public string LastName { get; set; } = string.Empty;

    
    public string Allergies { get; set; } = string.Empty;


    public int AmountOfSeats { get; set; }

    
    public string Email { get; set; } = string.Empty;

    
    public string PhoneNumber { get; set; } = string.Empty;
}