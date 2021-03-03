using Domain.Payment;
using Services.PaymentGateway.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PaymentGateway.Implementation
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool IsAvailable()
        {
            // check the availability and return true if available and false if not available
            return true;
        }

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
