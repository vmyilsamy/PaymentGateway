using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewayApi.Interfaces;

namespace PaymentGatewayApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentHistoryController : ControllerBase
{
    private readonly IPaymentHistoryService _paymentHistoryService;

    public PaymentHistoryController(IPaymentHistoryService paymentHistoryService)
    {
        _paymentHistoryService = paymentHistoryService;
    }

    /// <summary>
    /// Gets the historical payment details for a given transaction id(GUID)
    /// </summary>
    /// <param name="transactionId">Guid</param>
    /// <returns>Payment history</returns>
    /// <exception cref="ArgumentException"></exception>
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    [HttpGet("Get Payment Details")]
    public async Task<ObjectResult> GetPaymentDetails(Guid transactionId)
    {
        if (transactionId == Guid.Empty)
        {
            throw new ArgumentException();
        }

        var historicalPayment = await _paymentHistoryService.GetPaymentDetailBy(transactionId);

        if (historicalPayment == null)
        {
            return NotFound($"Payment history not found for transaction id: {transactionId}");
        }

        return Ok(historicalPayment);
    }
}