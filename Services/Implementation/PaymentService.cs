using DAL.Infrastructure;
using Domain.Enums;
using Domain.Payment;
using Microsoft.EntityFrameworkCore;
using Services.PaymentGateway.Implementation;
using Services.PaymentGateway.Infrastructure;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork unitOfWork;
        private IExpensivePaymentGateway expensivePaymentGateway;
        private ICheapPaymentGateway cheapPaymentGateway;
        private IPremiumPaymentGateway premiumPaymentGateway;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.expensivePaymentGateway = new ExpensivePaymentGateway();
            this.cheapPaymentGateway = new CheapPaymentGateway();
            this.premiumPaymentGateway = new PremiumPaymentGateway();
        }

        public bool ProcessRequest(PaymentRequest PaymentRequest)
        {
            unitOfWork.BeginTransaction();

            try
            {
                unitOfWork.PaymentRequest.Add(PaymentRequest);
                unitOfWork.SaveChanges();

                unitOfWork.PaymentRequestState.Add(new PaymentRequestState { PaymentRequestId = PaymentRequest.PaymentRequestId, State = (int)PaymentState.Pending, AdditionDate = DateTime.Now });
                unitOfWork.SaveChanges();

                bool paymentProccessed = false;

                if (PaymentRequest.Amount <= 20)
                {
                    paymentProccessed = cheapPaymentGateway.ProccessRequest(PaymentRequest);
                }
                else if (PaymentRequest.Amount >= 21 && PaymentRequest.Amount <= 500)
                {
                    if (expensivePaymentGateway.IsAvailable())
                        paymentProccessed = expensivePaymentGateway.ProccessRequest(PaymentRequest);
                    else
                        paymentProccessed = cheapPaymentGateway.ProccessRequest(PaymentRequest);
                }
                else
                {
                    paymentProccessed = premiumPaymentGateway.ProccessRequest(PaymentRequest, 1);
                }

                UpdateRequest(PaymentRequest.PaymentRequestId, paymentProccessed);

                unitOfWork.Commit();
                return paymentProccessed;
            }
            catch
            {
                unitOfWork.RollBack();
                return false;
            }
        }

        private void UpdateRequest(int paymentRequestId, bool paymentProccessed)
        {
            var request = unitOfWork.PaymentRequestState.FirstOrDefault(d => d.PaymentRequestId == paymentRequestId);
            request.UpdationDate = DateTime.Now;
            request.State = paymentProccessed ? (int)PaymentState.Completed : (int)PaymentState.Failed;
            unitOfWork.SaveChanges();
        }
    }
}
