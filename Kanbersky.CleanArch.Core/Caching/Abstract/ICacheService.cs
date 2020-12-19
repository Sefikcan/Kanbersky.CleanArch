using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Core.Caching.Abstract
{
    public interface ICacheService
    {
        T Get<T>(string key);

        Task<T> GetAsync<T>(string key);

        object Get(string key);

        Task<object> GetAsync(string key);

        void Add(string key, object data, double duration);

        Task<T> AddAsync<T>(string key, T data, double duration);

        bool IsExists(string key);

        Task<bool> IsExistsAsync(string key);

        void Remove(string key);

        Task RemoveAsync(string key);
    }
}
