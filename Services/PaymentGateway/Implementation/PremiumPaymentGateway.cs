using Domain.Payment;
using Services.PaymentGateway.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PaymentGateway.Implementation
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public bool ProccessRequest(PaymentRequest paymentRequest, int retryFlag)
        {
            bool proccessingComplete = true;

            try
            {
                // proccessing go here
            }
            catch
            {
                proccessingComplete = false;
            }

            if (retryFlag <= 3 && proccessingComplete == false)
                proccessingComplete = ProccessRequest(paymentRequest, retryFlag++);

            return proccessingComplete;
        }
    }
}
