using oubliette.Handlers;
using static System.Environment;

namespace Oubliette.Services
{
    public class DownloadsWatcherService : BackgroundService, IDisposable
    {
        private readonly ILogger<DownloadsWatcherService> _logger;
        private readonly IFileHandler _handler;
        private readonly string _downloadsPath;
        private readonly FileSystemWatcher _watcher;

        public DownloadsWatcherService(ILogger<DownloadsWatcherService> logger, IFileHandler handler)
        {
            _logger = logger;
            _handler = handler;
            _downloadsPath = Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile), "Downloads");
            _watcher =  new FileSystemWatcher(_downloadsPath);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"DownloadsWatcherService is starting - listening to {_downloadsPath}");
            _watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            _watcher.Created += OnCreated;

            _watcher.Filter = "*";
            _watcher.IncludeSubdirectories = false;
            _watcher.EnableRaisingEvents = true;

            
            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogInformation("Stopping DownloadsWatcherService");
            _watcher.Created -= OnCreated;
        }

        private void OnCreated(object sender, FileSystemEventArgs e) => _handler?.HandleFile(sender, e);
    }
}