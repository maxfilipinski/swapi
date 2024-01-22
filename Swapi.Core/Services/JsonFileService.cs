using Microsoft.Extensions.Logging;
using Swapi.Core.Interfaces;
using System.Reflection;
using System.Text.Json;

namespace Swapi.Core.Services
{
    public class JsonFileService : IFileService
    {
        private readonly ILogger<Application> _logger;

        public JsonFileService(ILogger<Application> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(JsonFileService)} initialized");
        }

        public async void WriteToFile(object data, bool writeIndented = true)
        {
            _logger.LogInformation($"Running {nameof(JsonFileService)}.{nameof(WriteToFile)}...");

            // For development purposes the basePath has been explicitly set to ~\Data\Json, not ~\bin\...
            var basePath = $"{Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.FullName}\\Data\\Json";
            var fileName = $"{basePath}\\{data.GetType().Name.ToLower()}data.txt";

            try
            {
                if (!Directory.Exists(basePath))
                {
                    _logger.LogInformation($"Directory {basePath} not found. Creating new directory...");

                    Directory.CreateDirectory(basePath!);
                }

                await using FileStream fileStream = File.Create(fileName);
                await JsonSerializer.SerializeAsync(fileStream, data, new JsonSerializerOptions
                {
                    WriteIndented = writeIndented
                });

                _logger.LogInformation($"Writing to {fileName} successful");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(JsonFileService)}.{nameof(WriteToFile)} failed unexpectedly. Error: {ex}");
                
                File.CreateText(fileName).Close();
            }
        }
    }
}
