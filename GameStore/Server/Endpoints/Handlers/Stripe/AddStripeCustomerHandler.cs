using GameStore.Server.Endpoints.Requests.Stripe;
using GameStore.Service.Services.StripeServices;
using GameStore.Shared.DataModels.Stripe;
using GameStore.Shared.Services.StripeInterfaces;
using MediatR;
using Stripe;

namespace GameStore.Server.Endpoints.Handlers.Stripe;

public class AddStripeCustomerHandler : IRequestHandler<AddStripeCustomerRequest, IResult>
{
    private readonly IStripeAppService _stripeAppService;

    public AddStripeCustomerHandler(IStripeAppService stripeAppService)
    {
        _stripeAppService = stripeAppService;
    }

    public async Task<IResult> Handle(AddStripeCustomerRequest request, CancellationToken cancellationToken)
    {
        StripeCustomer createdCustomer = await _stripeAppService.AddStripeCustomerAsync(request.StripeCustomer, cancellationToken);

        return Results.Ok(createdCustomer);
    }
}
