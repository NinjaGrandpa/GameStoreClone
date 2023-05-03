using GameStore.Shared.DataModels.Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.Services.StripeInterfaces
{
    public interface IStripeAppService
    {
        Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken cancellationToken);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken cancellationToken);
    }
}
