using oubliette.Handlers;
using Oubliette.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileHandler, FileHandler3D>();
        services.AddSingleton<IFileHandler, DocumentationFileHandler>();
        services.AddSingleton<IFileHandler, AudioFileHandler>();
        services.AddSingleton<IFileHandler, VideoFileHandler>();
        services.AddSingleton<IFileHandler, ImageFileHandler>();
        services.AddSingleton<IFileHandler, ArchiveFileHandler>();
        services.AddSingleton<IFileHandler, DataFileHandler>();
        services.AddSingleton<IFileHandler, ScriptFileHandler>();
        services.AddSingleton<IFileHandler, FontFileHandler>();
        services.AddSingleton<FileHandlerRouter>();
        services.AddHostedService<DownloadsWatcherService>();
        services.AddHostedService<DownloadsCleanupService>();
    })
    .Build();

await host.RunAsync();
