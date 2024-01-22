using Microsoft.Extensions.Logging;
using Swapi.Core.Entities;
using Swapi.Core.Interfaces;

namespace Swapi.Core.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ILogger<Application> _logger;
        private readonly IDataService<T> _dataService;

        public Repository(ILogger<Application> logger, IDataService<T> dataService)
        {
            _logger = logger;
            _dataService = dataService;

            _logger.LogInformation($"{nameof(Repository<T>)} initialized");
        }

        public async Task<T> GetEntityAsync()
        {
            _logger.LogInformation($"Running {nameof(Repository<T>)}.{nameof(GetEntityAsync)}...");

            return await _dataService.GetDataResultAsync();
        }
    }
}
