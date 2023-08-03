using System.Threading.Tasks;
using PaymentGatewayApi.Request;
using PaymentGatewayApi.Response;

namespace PaymentGatewayApi.Interfaces
{
    public interface IAcquiringBankClient
    {
        Task<AcquiringBankPaymentResponse> ProcessPayment(AcquiringBankPaymentRequest paymentRequest);
    }
}