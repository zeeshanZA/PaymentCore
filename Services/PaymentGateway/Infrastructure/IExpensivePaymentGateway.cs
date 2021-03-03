﻿using Domain.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PaymentGateway.Infrastructure
{
    public interface IExpensivePaymentGateway
    {
        bool IsAvailable();
        bool ProccessRequest(PaymentRequest paymentRequest);
    }
}
