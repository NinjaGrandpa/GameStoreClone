using GameStore.Shared.DataModels.Enums;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Shared.DTO
{
    public class ProductOrderDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public List<ProductOrderDetailsDto> OrderDetails { get; set; } = new List<ProductOrderDetailsDto>();

        public DateTime CreatedDate { get; set; }

        public OrderStatus Status { get; set; }

        [Precision(38, 2)]
        public decimal OrderCost { get; set; }

        public byte[]? RowVersion { get; set; }
    }
}
