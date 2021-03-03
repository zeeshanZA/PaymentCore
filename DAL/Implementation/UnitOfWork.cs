using DAL.Infrastructure;
using DAL.Models;
using Domain.Payment;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private PaymentContext _dbContext;
        private IDbContextTransaction _transaction = null;
        public UnitOfWork()
        {
            _dbContext = new PaymentContext();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void RollBack()
        {
            _transaction.Rollback();
        }

        public IRepository<PaymentRequest> PaymentRequest => new EFRepository<PaymentRequest>(_dbContext);
        public IRepository<PaymentRequestState> PaymentRequestState => new EFRepository<PaymentRequestState>(_dbContext);
    }
}
