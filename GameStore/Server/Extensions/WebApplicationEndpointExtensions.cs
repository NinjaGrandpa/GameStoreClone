using GameStore.Server.Extensions.EndpointsGrouped;

namespace GameStore.Server.Extensions
{
    public static class WebApplicationEndpointExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            app.MapGroup("/event").MapEventGroup().WithTags("Event");
            app.MapGroup("/eventOrder").MapEventOrderGroup().WithTags("EventOrder");
            app.MapGroup("/customer").MapCustomerGroup().WithTags("Customer");
            app.MapGroup("/mail").MapMailGroup().WithTags("Mail");
            app.MapGroup("/api").MapStripeCustomerEndpoints().WithTags("Stripe");
            app.MapGroup("/product").MapProductGroup().WithTags("Product");
            app.MapGroup("/productOrders").MapGroupProductOrders().WithTags("ProductOrder");
            app.MapGroup("/cart").MapCartGroup().WithTags("Cart");

            return app;
        }
    }
}
