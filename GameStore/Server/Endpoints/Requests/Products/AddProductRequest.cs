using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Products;

public class AddProductRequest : IHttpRequest
{
    public ProductDto Product { get; set; }
}