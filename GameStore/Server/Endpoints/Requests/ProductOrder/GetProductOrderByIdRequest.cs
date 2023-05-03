namespace GameStore.Server.Endpoints.Requests.ProductOrder
{
    public class GetProductOrderByIdRequest : IHttpRequest
    {
        public Guid OrderId { get; set; }
    }
}
