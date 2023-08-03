using System.Threading.Tasks;
using PaymentGatewayApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewayApi.Examples;
using Swashbuckle.AspNetCore.Filters;
using PaymentGatewayApi.Request;

namespace PaymentGatewayApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Process a payment for a given merchant
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <returns>Returns a successful or failed payment response</returns>
        [ProducesResponseType(200)]
        [HttpPost("Submit payment request")]
        [SwaggerRequestExample(typeof(PaymentRequest), typeof(ExamplePaymentRequestProvider))]
        public async Task<ObjectResult> ProcessPayment(PaymentRequest paymentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentResponse = await _paymentService.ProcessPayment(paymentRequest);

            return Ok(paymentResponse);
        }
    }

    
}