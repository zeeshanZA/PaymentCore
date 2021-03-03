using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payment
{
    public class PaymentRequestState
    {
        public int PaymentRequestStateId { get; set; }
        public int PaymentRequestId { get; set; }
        public int State { get; set; }
        public DateTime AdditionDate { get; set; }
        public DateTime UpdationDate { get; set; }

        public virtual PaymentRequest PaymentRequest { get; set; }
    }
}
