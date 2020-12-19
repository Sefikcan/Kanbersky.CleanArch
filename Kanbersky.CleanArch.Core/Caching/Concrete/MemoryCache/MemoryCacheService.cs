using Kanbersky.CleanArch.Core.Caching.Abstract;
using Kanbersky.CleanArch.Core.Results.Exceptions.Concrete;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Core.Caching.Concrete.MemoryCache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object data, double duration)
        {
            _memoryCache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public Task<T> AddAsync<T>(string key, T data, double duration)
        {
            throw BaseException.NotImplementedException("Method not implemented");
        }

        public T Get<T>(string key)
        {
            var getCacheResponse = _memoryCache.Get(key);
            if (getCacheResponse != null)
            {
                return (T)getCacheResponse;
            }

            return default;
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw BaseException.NotImplementedException("Method not implemented");
        }

        public Task<object> GetAsync(string key)
        {
            throw BaseException.NotImplementedException("Method not implemented");
        }

        public bool IsExists(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public Task<bool> IsExistsAsync(string key)
        {
            throw BaseException.NotImplementedException("Method not implemented");
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public Task RemoveAsync(string key)
        {
            throw BaseException.NotImplementedException("Method not implemented");
        }
    }
}
