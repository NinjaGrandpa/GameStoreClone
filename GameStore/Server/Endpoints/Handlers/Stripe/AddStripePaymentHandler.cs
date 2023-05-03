using GameStore.Server.Endpoints.Requests.Stripe;
using GameStore.Service.Services.StripeServices;
using GameStore.Shared.DataModels.Stripe;
using GameStore.Shared.Services.StripeInterfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Stripe
{
    public class AddStripePaymentHandler : IRequestHandler<AddStripePaymentRequest, IResult>
    {

        private readonly IStripeAppService _stripeAppService;

        public AddStripePaymentHandler(IStripeAppService  stripeAppService)
        {
            _stripeAppService = stripeAppService;
        }

        public async Task<IResult> Handle(AddStripePaymentRequest request, CancellationToken cancellationToken)
        {
            StripePayment createdPayment = await _stripeAppService.AddStripePaymentAsync(request.StripePayment, cancellationToken);

            return Results.Ok(createdPayment);
        }
    }
}
