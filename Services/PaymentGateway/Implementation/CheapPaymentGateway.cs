using Domain.Payment;
using Services.PaymentGateway.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PaymentGateway.Implementation
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public bool ProccessRequest(PaymentRequest paymentRequest)
        {
            try
            {
                // proccessing go here

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
