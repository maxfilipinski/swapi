using Microsoft.Extensions.Logging;
using Swapi.Core.Entities;
using Swapi.Core.Interfaces;

namespace Swapi.Core
{
    public interface IApplication
    {
        void Run();
    }

    public class Application : IApplication
    {
        private readonly ILogger<Application> _logger;
        private readonly IExecutor<MyPerson> _executor;

        public Application(ILogger<Application> logger, IExecutor<MyPerson> executor)
        {
            _logger = logger;
            _executor = executor;
        }

        public void Run()
        {
            _logger.LogInformation("App started");

            _executor.ExecuteAsync();

            Console.ReadLine();
        }
    }
}
