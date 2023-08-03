using System.Threading.Tasks;
using PaymentGatewayApi.Request;
using PaymentGatewayApi.Response;

namespace PaymentGatewayApi.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest);
    }
}