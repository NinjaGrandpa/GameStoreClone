using GameStore.Server.Endpoints.Requests.ProductOrder;

namespace GameStore.Server.Extensions.EndpointsGrouped
{
    public static class ProductOrderGroupBuilderExtensions
    {
        public static RouteGroupBuilder MapGroupProductOrders(this RouteGroupBuilder builder)
        {
            builder.MediateGet<GetProductOrderByIdRequest>("/{id}");
            builder.MediateGet<GetAllProductOrdersRequest>("/all");
            builder.MediatePut<UpdateProductOrderRequest>("/");
            builder.MediatePost<AddProductOrderRequest>("/");
            builder.MediateDelete<RemoveProductOrderRequest>("/{id}");
            
            return builder;
        }
    }
}
