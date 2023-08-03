using PaymentGatewayApi.Request;
using Swashbuckle.AspNetCore.Filters;

namespace PaymentGatewayApi.Examples;

public class ExamplePaymentRequestProvider : IExamplesProvider<PaymentRequest>
{
    public PaymentRequest GetExamples()
    {
        return new PaymentRequest
        {
            Amount = 1,
            CardNumber = "4169773331987017",
            Currency = "GBP",
            Cvv = 123,
            ExpiryMonthYear = "12/24"
        };
    }
}