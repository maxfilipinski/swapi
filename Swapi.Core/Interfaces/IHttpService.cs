using Swapi.Core.Entities;

namespace Swapi.Core.Interfaces
{
    public interface IHttpService<T> where T : BaseEntity
    {
        Task<T?> HttpGetAsync();
        Task<T?> HttpGetAsync(string url);
    }
}
