using System;

namespace PaymentGatewayApi.Response;

public class AcquiringBankPaymentResponse
{
    public AcquiringBankPaymentResponse(Guid transactionId, int paymentStatus)
    {
        TransactionId = transactionId;
        PaymentStatus = paymentStatus;
    }

    public Guid TransactionId { get; set; }
    public int PaymentStatus { get; set;}
}