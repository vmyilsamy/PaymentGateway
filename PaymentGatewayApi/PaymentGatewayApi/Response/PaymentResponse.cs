using System;

namespace PaymentGatewayApi.Response;

public class PaymentResponse 
{
    public PaymentResponse(Guid transactionId, string paymentStatus)
    {
        TransactionId = transactionId;
        PaymentStatus = paymentStatus;
    }

    public Guid TransactionId { get; set; }

    public string PaymentStatus { get; set; }
}