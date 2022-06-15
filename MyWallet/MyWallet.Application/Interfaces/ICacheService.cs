using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface ICacheService
    {
        void Remove(string cacheKey);
        T Set<T>(string cacheKey, T value);
        bool TryGet<T>(string cacheKey, out T value);
    }
}
