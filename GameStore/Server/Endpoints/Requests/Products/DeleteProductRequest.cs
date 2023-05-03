namespace GameStore.Server.Endpoints.Requests.Products;

public class DeleteProductRequest : IHttpRequest
{
    public Guid Id { get; set; }
}