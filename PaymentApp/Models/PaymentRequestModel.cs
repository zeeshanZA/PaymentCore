using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Models
{
    public class PaymentRequestModel
    {
        public int paymentRequestId { get; set; }
        public string creditCardNumber { get; set; }
        public string cardHolder { get; set; }
        public DateTime? expirationDate { get; set; }
        public string securityCode { get; set; }
        public decimal? amount { get; set; }
    }
}
