using Domain.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class PaymentContext : DbContext
    {
        public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }
        public virtual DbSet<PaymentRequestState> PaymentRequestState { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\MSSQLSERVER01;Database=PaymentDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Property Configurations
            modelBuilder.Entity<PaymentRequest>()
                    .Property(s => s.SecurityCode).HasMaxLength(3);
        }
    }
}
