using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Persistence.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IOptions<CacheSettings> _cacheSettings;
        private MemoryCacheEntryOptions _cacheOptions;

        public CacheService(IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings;

            if (_cacheSettings != null)
            {
                _cacheOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(_cacheSettings.Value.SlidingExpiration),
                    Priority = CacheItemPriority.Normal,
                    Size = 512
                };
            }
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        public T Set<T>(string cacheKey, T value)
        {
            return _memoryCache.Set(cacheKey, value);
        }

        public bool TryGet<T>(string cacheKey, out T value)
        {
            _memoryCache.TryGetValue(cacheKey, out value);
            if (value == null) return false;
            else return true;
        }

    }
}
    

