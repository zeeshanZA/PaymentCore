using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payment
{
    public class PaymentRequest
    {
        public int PaymentRequestId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<PaymentRequestState> PaymentRequestStates { get; set; }
    }
}
