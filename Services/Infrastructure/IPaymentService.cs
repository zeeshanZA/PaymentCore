using Domain.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Infrastructure
{
    public interface IPaymentService
    {
        bool ProcessRequest(PaymentRequest paymentRequestModel);
    }
}
