using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Swapi.Core;
using Swapi.Core.Data;
using Swapi.Core.Interfaces;
using Swapi.Core.Services;

var host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddSingleton<IApplication, Application>();
        services.AddTransient(typeof(IExecutor<>), typeof(Executor<>));
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient(typeof(IDataService<>), typeof(DataService<>));
        services.AddTransient(typeof(IHttpService<>), typeof(HttpService<>));
        services.AddTransient<IFileService, JsonFileService>();
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            loggingBuilder.AddNLog();
        }).BuildServiceProvider();
    }).Build();

var app = host.Services.GetRequiredService<IApplication>();
app.Run();