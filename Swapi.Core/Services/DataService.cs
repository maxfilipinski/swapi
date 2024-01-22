using Microsoft.Extensions.Logging;
using Swapi.Core.Entities;
using Swapi.Core.Interfaces;

namespace Swapi.Core.Services
{
    public class DataService<T> : IDataService<T> where T : BaseEntity
    {
        private readonly ILogger<Application> _logger;
        private readonly IHttpService<T> _httpService;
        private readonly IFileService _jsonFileService;

        public DataService(ILogger<Application> logger,
            IHttpService<T> httpService,
            IFileService fileService)
        {
            _logger = logger;
            _httpService = httpService;
            _jsonFileService = fileService;

            _logger.LogInformation($"{nameof(DataService<T>)} initialized");
        }

        public async Task<T> GetDataResultAsync()
        {
            _logger.LogInformation($"Running {nameof(DataService<T>)}.{nameof(GetDataResultAsync)}...");

            var data = await _httpService.HttpGetAsync();
            if (data is null)
            {
                _logger.LogWarning($"{nameof(HttpService<T>.HttpGetAsync)} returned null. Returning new() for type {nameof(data.GetType)}.");

                return Activator.CreateInstance(typeof(T)) as T;
            }
            if (data is MyPerson)
            {
                HandleMyPersonType(data as MyPerson);

                return data;
            }

            _jsonFileService.WriteToFile(data);

            return data;
        }

        private async void HandleMyPersonType(MyPerson myPerson)
        {
            var filmsHttpService = new HttpService<Film>(_logger);
            foreach (var url in myPerson.FilmUrls)
            {
                var filmTitle = await filmsHttpService.HttpGetAsync(url);
                if (filmTitle is null)
                {
                    // TODO: retry mechanism?
                    _logger.LogWarning($"Getting film title for {url} failed. Value will be skipped in the final object.");
                    continue;
                }

                myPerson.FilmTitles.Add(filmTitle);
            }

            var starshipsHttpService = new HttpService<Starship>(_logger);
            foreach (var url in myPerson.StarshipUrls)
            {
                var starshipName = await starshipsHttpService.HttpGetAsync(url);
                if (starshipName is null)
                {
                    // TODO: retry mechanism?
                    _logger.LogWarning($"Getting starship name for {url} failed. Value will be skipped in the final object.");
                    continue;
                }

                myPerson.StarshipNames.Add(starshipName);
            }

            var vehiclesHttpService = new HttpService<Vehicle>(_logger);
            foreach (var url in myPerson.VehicleUrls)
            {
                var vehicleName = await vehiclesHttpService.HttpGetAsync(url);
                if (vehicleName is null)
                {
                    // TODO: retry mechanism?
                    _logger.LogWarning($"Getting vehicle name for {url} failed. Value will be skipped in the final object.");
                    continue;
                }

                myPerson.VehicleNames.Add(vehicleName);
            }

            _jsonFileService.WriteToFile(myPerson);
        }
    }
}
