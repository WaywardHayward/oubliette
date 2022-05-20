namespace oubliette.Handlers
{
    public class FileHandlerRouter
    {
        private readonly ILogger<FileHandlerRouter> _logger;
        private readonly IEnumerable<IFileHandler> _fileHandlers;

        public FileHandlerRouter(ILogger<FileHandlerRouter> logger, IEnumerable<IFileHandler> fileHandlers){
            _logger = logger;
            _fileHandlers = fileHandlers;
        }

        public void HandleFile(object sender, FileSystemEventArgs e){
            var file = new FileInfo(e.FullPath);
            var extension = file.Extension.ToLowerInvariant();
            var handler = _fileHandlers.FirstOrDefault(h => h.Extensions.Contains(extension));            
            if(handler == null){
                _logger.LogWarning($"No handler found for file {file.FullName}");
                return;
            }
            handler.HandleFile(sender, e);
        }
    }
}