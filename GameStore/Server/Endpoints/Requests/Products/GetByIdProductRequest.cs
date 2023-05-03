namespace GameStore.Server.Endpoints.Requests.Products;

public class GetByIdProductRequest : IHttpRequest
{
    public Guid Id { get; set; }
}