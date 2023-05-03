using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Products;

public class UpdateProductRequest : IHttpRequest
{
    public ProductDto Product { get; set; }
}