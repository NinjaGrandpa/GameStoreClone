using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.ProductOrder
{
    public class UpdateProductOrderRequest : IHttpRequest
    {
        public ProductOrderDto ProductOrder { get; set; }
    }
}
