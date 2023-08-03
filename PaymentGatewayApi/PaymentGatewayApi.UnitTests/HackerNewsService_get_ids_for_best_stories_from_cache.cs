using PaymentGatewayApi.Response;
using Given.Common;
using Given.NUnit;
using NUnit.Framework;
using PaymentGatewayApi.Extensions;
using PaymentGatewayApi.Request;
using Shouldly;

namespace PaymentGatewayApi.UnitTests
{
    [TestFixture]
    public class ModelExtensions_check_card_masking_in_acquiring_bank_payment_response_conversion_to_historical_payment_repsonse : Scenario
    {
        private static readonly string CardNumber = "4169773331987017";
        private static readonly string ExpectedCardNumber = "xxxx-xxxx-xxxx-7017";
        private static AcquiringBankPaymentResponse _acquiringBankPaymentResponse;
        private static HistoricalPayment _historicalPayment;

        private given a_acquiring_bank_payment_response = () =>
        {
            _acquiringBankPaymentResponse = new AcquiringBankPaymentResponse(Guid.NewGuid(), 1);
        };

        private when I_convert_it_to_historical_payment_response = () =>
        {
            var paymentRequest = new PaymentRequest
            {
                Amount = 1,
                CardNumber = CardNumber,
                Currency = "GBP",
                Cvv = 123,
                ExpiryMonthYear = "12/24"
            };

            _historicalPayment = _acquiringBankPaymentResponse.ToHistoricalPayment(paymentRequest);
        };

        [then]
        public void should_mask_card_number_and_expose_last_4_digits()
        {
            _historicalPayment.CardNumber.ShouldBe(ExpectedCardNumber);
        }
    }
}