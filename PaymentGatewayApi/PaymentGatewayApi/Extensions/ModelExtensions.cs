using PaymentGatewayApi.Request;
using PaymentGatewayApi.Response;

namespace PaymentGatewayApi.Extensions;

public static class ModelExtensions
{
    public static AcquiringBankPaymentRequest ToAcquiringBankPaymentRequest(this PaymentRequest paymentRequest)
    {
        return new AcquiringBankPaymentRequest(paymentRequest.CardNumber, paymentRequest.ExpiryMonthYear, paymentRequest.Amount, paymentRequest.Currency, paymentRequest.Cvv);
    }

    public static PaymentResponse ToPaymentResponse(this AcquiringBankPaymentResponse acquiringBankPaymentResponse)
    {
        PaymentStatus paymentStatus = (PaymentStatus)acquiringBankPaymentResponse.PaymentStatus;

        return new PaymentResponse(acquiringBankPaymentResponse.TransactionId, paymentStatus.ToString());
    }

    public static HistoricalPayment ToHistoricalPayment(this AcquiringBankPaymentResponse acquiringBankPaymentResponse, PaymentRequest paymentRequest)
    {
        var cardNumber = $"xxxx-xxxx-xxxx-{paymentRequest.CardNumber.Substring(paymentRequest.CardNumber.Length - 4, 4)}";

        PaymentStatus paymentStatus = (PaymentStatus)acquiringBankPaymentResponse.PaymentStatus;

        return new HistoricalPayment(acquiringBankPaymentResponse.TransactionId, paymentStatus.ToString(), cardNumber, paymentRequest.ExpiryMonthYear, paymentRequest.Amount, paymentRequest.Currency, paymentRequest.Cvv);
    }
}