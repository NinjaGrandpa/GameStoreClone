﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.DataModels.Stripe
{
    public record AddStripePayment(string CustomerId, string ReceiptEmail, string Description, string Currency, long Amount)
    {
    }
}
