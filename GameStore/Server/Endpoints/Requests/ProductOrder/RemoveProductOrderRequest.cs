namespace GameStore.Server.Endpoints.Requests.ProductOrder
{
    public class RemoveProductOrderRequest : IHttpRequest
    {
        public Guid OrderId { get; set; }
    }
}
