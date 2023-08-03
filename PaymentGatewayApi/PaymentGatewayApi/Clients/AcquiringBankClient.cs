using System;
using System.Threading.Tasks;
using PaymentGatewayApi.Interfaces;
using PaymentGatewayApi.Request;
using PaymentGatewayApi.Response;

namespace PaymentGatewayApi.Clients
{
    public class MockAcquiringBankClient : IAcquiringBankClient
    {
        public async Task<AcquiringBankPaymentResponse> ProcessPayment(AcquiringBankPaymentRequest paymentRequest)
        {
            var paymentStatus = PaymentStatus.Pending;

            switch (paymentRequest.Amount)
            {
                case 1:
                    paymentStatus = PaymentStatus.Success;
                    break;
                case 2:
                    paymentStatus = PaymentStatus.Failed;
                    break;
                case 3:
                    paymentStatus = PaymentStatus.Fraud;
                    break;
            }

            await Task.CompletedTask;

            return new AcquiringBankPaymentResponse(Guid.NewGuid(), (int)paymentStatus);
        }
    }
}