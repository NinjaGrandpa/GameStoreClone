using GameStore.Server.Endpoints.Requests.Stripe;

namespace GameStore.Server.Extensions.EndpointsGrouped
{
    public static class StripeGroupBuilderExtensions
    {
        public static RouteGroupBuilder MapStripeCustomerEndpoints(this RouteGroupBuilder builder)
        {
            builder.MediatePost<AddStripeCustomerRequest>("/");
            builder.MediatePost<AddStripePaymentRequest>("/{payment}");

            return builder;
        }
    }
}
