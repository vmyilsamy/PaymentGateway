using PaymentGatewayApi.Interfaces;
using PaymentGatewayApi.Request;
using PaymentGatewayApi.Response;
using PaymentGatewayApi.Services;
using Given.Common;
using Given.NUnit;
using Moq;
using NUnit.Framework;
using PaymentGatewayApi.Request;

namespace PaymentGatewayApi.UnitTests
{
    [TestFixture]
    public class PaymentService_Process_payment_should_write_payment_response_to_repository : Scenario
    {
        private static IPaymentService _paymentService;
        private static readonly Mock<IAcquiringBankClient> AcquiringBankClientMock = new Mock<IAcquiringBankClient>();
        private static readonly Mock<IRepository> RepositoryMock = new Mock<IRepository>();
        private static PaymentRequest _paymentRequest;
        private static PaymentResponse _paymentResponse;

        private given a_payment_request = () =>
        {
            _paymentRequest = new PaymentRequest
            {
                Amount = 1,
                CardNumber = "4169773331987017",
                Currency = "GBP",
                Cvv = 123,
                ExpiryMonthYear = "12/24"
            };

            AcquiringBankClientMock.Setup(client => client.ProcessPayment(It.IsAny<AcquiringBankPaymentRequest>())).ReturnsAsync(new AcquiringBankPaymentResponse(Guid.NewGuid(), 1));

            _paymentService = new PaymentService(AcquiringBankClientMock.Object, RepositoryMock.Object);
        };

        private when I_request_to_process_a_payment = () =>
        {
            _paymentResponse = _paymentService.ProcessPayment(_paymentRequest).GetAwaiter().GetResult();
        };

        [then]
        public void should_call_acquiring_bank_client_to_process_payment()
        {
            AcquiringBankClientMock.Verify(client => client.ProcessPayment(It.Is<AcquiringBankPaymentRequest>(abpr => abpr.CardNumber == _paymentRequest.CardNumber)), Times.Once);
        }

        [then]
        public void should_store_payment_response_in_payment_repository()
        {
            RepositoryMock.Verify(repo => repo.Add(It.Is<Guid>(txnId => txnId == _paymentResponse.TransactionId), It.Is<HistoricalPayment>(hp => hp.Amount == _paymentRequest.Amount)), Times.Once);
        }
    }
}