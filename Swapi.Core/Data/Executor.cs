using Microsoft.Extensions.Logging;
using Swapi.Core.Entities;
using Swapi.Core.Interfaces;

namespace Swapi.Core.Data
{
    public class Executor<T> : IExecutor<T> where T : BaseEntity
    {
        private readonly ILogger<Application> _logger;
        private readonly IRepository<T> _repository;

        public Executor(ILogger<Application> logger, IRepository<T> repository)
        {
            _logger = logger;
            _repository = repository;

            _logger.LogInformation($"{nameof(Executor<T>)} initialized");
        }

        public async void ExecuteAsync()
        {
            _logger.LogInformation($"Running {nameof(Executor<T>)}.{nameof(ExecuteAsync)}...");

            await _repository.GetEntityAsync();
        }
    }
}
