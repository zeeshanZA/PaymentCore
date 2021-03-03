﻿using Domain.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PaymentGateway.Infrastructure
{
    public interface IPremiumPaymentGateway
    {
        bool ProccessRequest(PaymentRequest paymentRequest, int retryFlag);
    }
}
