using System.Threading.Tasks;

namespace PaymentGatewayApi.Interfaces
{
    public interface IRepository
    {
        T Get<T>(object cacheKey);
        Task Add<T>(object cacheKey, T item);
    }
}