using GameStore.Shared.DataModels.Stripe;

namespace GameStore.Server.Endpoints.Requests.Stripe
{
    public class AddStripeCustomerRequest : IHttpRequest
    {
        public AddStripeCustomer StripeCustomer { get; set; }
    }
}
