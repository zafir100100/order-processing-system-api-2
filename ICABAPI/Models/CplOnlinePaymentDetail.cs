using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class CplOnlinePaymentDetail
    {
        public decimal Id { get; set; }
        public decimal ExamLevel { get; set; }
        public decimal MonthId { get; set; }
        public decimal SessionYear { get; set; }
        public decimal? RegNo { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string SessionKey { get; set; }
        public string Status { get; set; }
        public string CardType { get; set; }
        public DateTime? PaymentTime { get; set; }
        public string Name { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
        public decimal? Annfeepayslipamt { get; set; }
        public string RedirectUrl { get; set; }
        public string PaymentError { get; set; }
    }
}
