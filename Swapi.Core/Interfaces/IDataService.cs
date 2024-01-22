using Swapi.Core.Entities;

namespace Swapi.Core.Interfaces
{
    public interface IDataService<T> where T : BaseEntity
    {
        Task<T> GetDataResultAsync();
    }
}
