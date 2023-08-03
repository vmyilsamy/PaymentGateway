using System.Threading.Tasks;
using PaymentGatewayApi.Extensions;
using PaymentGatewayApi.Interfaces;
using PaymentGatewayApi.Request;
using PaymentGatewayApi.Response;

namespace PaymentGatewayApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAcquiringBankClient _acquiringBankClient;
        private readonly IRepository _repository;

        public PaymentService(IAcquiringBankClient acquiringBankClient, IRepository repository)
        {
            _acquiringBankClient = acquiringBankClient;
            _repository = repository;
        }

        public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
        {
            var acquiringBankPaymentResponse = await _acquiringBankClient.ProcessPayment(paymentRequest.ToAcquiringBankPaymentRequest());

            var historicalPayment = acquiringBankPaymentResponse.ToHistoricalPayment(paymentRequest);

            await _repository.Add(acquiringBankPaymentResponse.TransactionId, historicalPayment);

            return acquiringBankPaymentResponse.ToPaymentResponse();
        }
    }
}