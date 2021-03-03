using DAL.Models;
using Domain.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void Commit();
        void RollBack();
        void BeginTransaction();
        IRepository<PaymentRequest> PaymentRequest { get; }
        IRepository<PaymentRequestState> PaymentRequestState { get; }
    }
}
