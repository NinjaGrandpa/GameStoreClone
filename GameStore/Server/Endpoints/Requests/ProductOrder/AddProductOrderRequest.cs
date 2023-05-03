using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.ProductOrder
{
    public class AddProductOrderRequest : IHttpRequest
    {
        public ProductOrderDto Order { get; set; }
    }
}
