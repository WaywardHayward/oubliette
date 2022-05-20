using oubliette.Handlers;
using static System.Environment;

namespace Oubliette.Services
{
    public class DownloadsCleanupService : BackgroundService
    {
        private readonly ILogger<DownloadsWatcherService> _logger;
        private readonly string _downloadsPath;
        private readonly IFileHandler _handler;

        public DownloadsCleanupService(ILogger<DownloadsWatcherService> logger,IFileHandler handler)
        {
            _logger = logger;
            _downloadsPath = Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile), "Downloads");
            _handler = handler;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("DownloadsCleanupService is starting - Cleaning ... {_downloadsPath}", _downloadsPath);
            
            var files = Directory.GetFiles(_downloadsPath, "*", SearchOption.TopDirectoryOnly);

            foreach(var file in files)
                _handler.HandleFile(this, new FileSystemEventArgs(WatcherChangeTypes.Created, _downloadsPath, Path.GetFileName(file)));

            _logger.LogInformation("DownloadsCleanupService is Cleaned {files} files from {_downloadsPath}",files.Length, _downloadsPath);

            return Task.CompletedTask;
        }
    }
}