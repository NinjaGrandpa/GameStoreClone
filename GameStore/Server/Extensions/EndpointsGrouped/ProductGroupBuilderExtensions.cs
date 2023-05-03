using GameStore.Server.Endpoints.Requests.Products;

namespace GameStore.Server.Extensions.EndpointsGrouped;

public static class ProductGroupBuilderExtensions
{
    public static RouteGroupBuilder MapProductGroup(this RouteGroupBuilder builder)
    {
        builder.MediateGet<GetAllProductsRequest>("/all");
        builder.MediateGet<GetByIdProductRequest>("/{id}");
        builder.MediatePost<AddProductRequest>("/");
        builder.MediatePut<UpdateProductRequest>("/");
        builder.MediateDelete<DeleteProductRequest>("/{id}");

        return builder;
    }
}