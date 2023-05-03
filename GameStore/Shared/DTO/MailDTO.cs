namespace GameStore.Shared.DTO
{
    public class MailDTO
    {
        public Guid EventOrderId { get; set; }
        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; }

        public string EventName { get; set; }

        public int Seats { get; set; }

        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
    }
}
