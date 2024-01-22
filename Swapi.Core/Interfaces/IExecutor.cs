using Swapi.Core.Entities;

namespace Swapi.Core.Interfaces
{
    public interface IExecutor<T> where T : BaseEntity
    {
        void ExecuteAsync();
    }
}
