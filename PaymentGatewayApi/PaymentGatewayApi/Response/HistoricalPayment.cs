using System;

namespace PaymentGatewayApi.Response
{
    public class HistoricalPayment
    {
        public HistoricalPayment(Guid transactionId, string paymentStatus, string cardNumber, string expiryMonthYear, decimal amount, string currency, int cvv)
        {
            TransactionId = transactionId;
            PaymentStatus = paymentStatus;
            CardNumber = cardNumber;
            ExpiryMonthYear = expiryMonthYear;
            Amount = amount;
            Currency = currency;
            Cvv = cvv;
        }

        public Guid TransactionId { get; set; }
        public string PaymentStatus { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonthYear { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int Cvv { get; set; }
    }
}