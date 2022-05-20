namespace oubliette.Handlers
{
    public abstract class MoveFileHandler : IFileHandler
    {
        protected ILogger _logger;

        protected MoveFileHandler(ILogger<MoveFileHandler> logger) => _logger = logger;

        protected abstract string GetDestination(FileInfo file);
        public abstract HashSet<string> Extensions { get; }
        public void HandleFile(object sender, FileSystemEventArgs e)
        {
            try
            {
                MoveUsingFileInfo(new FileInfo(e.FullPath));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error handling file {e.FullPath}");
            }
        }

        private void MoveUsingFileInfo(FileInfo file) => MoveTo(file, GetDestination(file));

        protected void MoveTo(FileInfo fileInfo, string destination)
        {
            if(!fileInfo.Exists) return;

            var destinationDir = Path.Combine(fileInfo.Directory.FullName, destination);
            var destinationPath = Path.Combine(destinationDir, fileInfo.Name);

            if (!Directory.Exists(destinationDir))
                Directory.CreateDirectory(destinationDir);

            if (File.Exists(destinationPath))
                destinationPath = AppendOrdinalSuffix(fileInfo, destinationDir, destinationPath);

            _logger.LogInformation("Moving file {fileName} to {destination}", fileInfo.Name, destinationPath);

            fileInfo.MoveTo(destinationPath);
        }

        private string AppendOrdinalSuffix(FileInfo fileInfo, string destinationDir, string destinationPath)
        {
            var count = 1;
            var name = Path.GetFileNameWithoutExtension(fileInfo.Name);
            var ordinalDestinationPath = destinationPath;

            while (File.Exists(ordinalDestinationPath))
            {
                string tempFileName = string.Format("{0}({1})", name, count++);
                ordinalDestinationPath = Path.Combine(destinationDir, tempFileName + fileInfo.Extension);
            }

            return ordinalDestinationPath;
        }
    }
}