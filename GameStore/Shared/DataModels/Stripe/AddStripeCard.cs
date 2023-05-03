using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.DataModels.Stripe
{
    public record AddStripeCard(string Name, string CardNumber, string ExpirationYear, string ExpirationMonth, string CvcNumber)
    {
    }
}
