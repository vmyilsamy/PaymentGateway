using System;
using System.Threading.Tasks;
using PaymentGatewayApi.Response;

namespace PaymentGatewayApi.Interfaces;

public interface IPaymentHistoryService
{
    Task<HistoricalPayment> GetPaymentDetailBy(Guid transactionId);
}