using System;
using System.Threading.Tasks;
using PaymentGatewayApi.Interfaces;
using PaymentGatewayApi.Response;

namespace PaymentGatewayApi.Services;

public class PaymentHistoryService : IPaymentHistoryService
{
    private readonly IRepository _repository;

    public PaymentHistoryService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<HistoricalPayment> GetPaymentDetailBy(Guid transactionId)
    {
        var historicalPayment = _repository.Get<HistoricalPayment>(transactionId);

        await Task.CompletedTask;

        return historicalPayment;
    }
}