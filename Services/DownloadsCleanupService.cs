using oubliette.Handlers;
using static System.Environment;

namespace Oubliette.Services
{
    public class DownloadsCleanupService : BackgroundService
    {
        private readonly ILogger<DownloadsWatcherService> _logger;
        private readonly string _downloadsPath;
        private readonly FileHandlerRouter _handlers;

        public DownloadsCleanupService(ILogger<DownloadsWatcherService> logger,FileHandlerRouter handler)
        {
            _logger = logger;
            _downloadsPath = Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile), "Downloads");
            _handlers = handler;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("DownloadsCleanupService is starting - Cleaning ... {_downloadsPath}", _downloadsPath);
            
            var files = Directory.GetFiles(_downloadsPath, "*", SearchOption.TopDirectoryOnly);

            foreach(var file in files){
                var fileInfo = new FileInfo(file);
                _handlers?.HandleFile(this, new FileSystemEventArgs(WatcherChangeTypes.Created, fileInfo.DirectoryName, fileInfo.Name));
            }
          
            _logger.LogInformation("DownloadsCleanupService is Cleaned {files} files from {_downloadsPath}",files.Length, _downloadsPath);

            return Task.CompletedTask;
        }
    }
}