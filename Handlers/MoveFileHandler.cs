namespace oubliette.Handlers
{
    public abstract class MoveFileHandler : IFileHandler
    {
        protected ILogger _logger;

        protected MoveFileHandler(ILogger<MoveFileHandler> logger) => _logger = logger;
        
        protected abstract string GetDestination(FileInfo file);
        public abstract HashSet<string> Extensions { get; }
        public void HandleFile(object sender, FileSystemEventArgs e) {
            var file = new FileInfo(e.FullPath);
            MoveTo(file, GetDestination(file));
        }

        protected void MoveTo(FileInfo fileInfo, string destination)
        {
            var destinationPath = Path.Combine(fileInfo.Directory.FullName, destination, fileInfo.Name);
            _logger.LogInformation("Moving file {fileName} to {destination}", fileInfo.Name, destinationPath);
            Directory.CreateDirectory(Path.Combine(fileInfo.Directory.FullName, destination));
            fileInfo.MoveTo(destinationPath);
        }
    }
}