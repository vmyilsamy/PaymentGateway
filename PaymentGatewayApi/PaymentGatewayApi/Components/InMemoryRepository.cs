using System;
using System.Threading;
using System.Threading.Tasks;
using PaymentGatewayApi.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace PaymentGatewayApi.Components
{
    public class InMemoryRepository : IRepository
    {
        private readonly IMemoryCache _memoryCache;

        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        public InMemoryRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(object cacheKey)
        {
            var item = _memoryCache.Get<T>(cacheKey);

            return item;
        }

        public async Task Add<T>(object cacheKey, T item)
        {
            try
            {
                await SemaphoreSlim.WaitAsync();

                _memoryCache.Set(cacheKey, item, DateTimeOffset.UtcNow.AddHours(24));
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }
    }
}