using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DTO
{
    public class ProductOrderDetailsDto
    {
        public Guid Id { get; set; }

        public Guid ProductOrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        [Precision(38, 2)]
        public decimal OrderDetailsCost { get; set; }
    }
}
