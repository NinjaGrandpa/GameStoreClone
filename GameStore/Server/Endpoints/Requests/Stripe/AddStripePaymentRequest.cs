using GameStore.Shared.DataModels.Stripe;

namespace GameStore.Server.Endpoints.Requests.Stripe;

public class AddStripePaymentRequest : IHttpRequest
{
    public AddStripePayment StripePayment { get; set; }
}
