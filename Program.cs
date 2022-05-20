using oubliette.Handlers;
using Oubliette.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileHandler, DownloadHandler>();
        services.AddHostedService<DownloadsWatcherService>();
        services.AddHostedService<DownloadsCleanupService>();
    })
    .Build();

await host.RunAsync();
