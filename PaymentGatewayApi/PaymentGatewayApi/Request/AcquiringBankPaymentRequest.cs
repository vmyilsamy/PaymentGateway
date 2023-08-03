namespace PaymentGatewayApi.Request;

public class AcquiringBankPaymentRequest
{
    public AcquiringBankPaymentRequest(string cardNumber, string expiryMonthYear, decimal amount, string currency, int cvv)
    {
        CardNumber = cardNumber;
        ExpiryMonthYear = expiryMonthYear;
        Amount = amount;
        Currency = currency;
        Cvv = cvv;
    }

    public string CardNumber { get; set; }
    public string ExpiryMonthYear { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public int Cvv { get; set; }
}