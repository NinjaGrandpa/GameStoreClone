using System.ComponentModel.DataAnnotations;

namespace GameStore.Shared.DTO;

public class CreditCardDTO
{
    [Required, StringLength(16)] public string CardNumber { get; set; } = string.Empty;

    [Required, StringLength(3)] public string CvcNumber { get; set; } = string.Empty;

    [Required] public DateTime ExpirationDate { get; set; }

    [Required] public string FirstName { get; set; } = string.Empty;

    [Required] public string LastName { get; set; } = string.Empty;


}