using Swapi.Core.Entities;

namespace Swapi.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetEntityAsync();
    }
}
