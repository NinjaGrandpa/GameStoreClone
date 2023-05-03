using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Shared.DataModels
{
    public class MailModel
    {

        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("EventOrder")]
        public Guid EventOrderId { get; set; }

        public EventOrderModel EventOrder { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
