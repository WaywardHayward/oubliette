using Oubliette.Services;

namespace oubliette.Handlers
{

    public class DownloadHandler : IFileHandler
    {
        private readonly ILogger<DownloadHandler> _logger;
        public DownloadHandler(ILogger<DownloadHandler> logger) =>_logger = logger;
        public void HandleFile(object sender, FileSystemEventArgs e)
        {
            var fileName = e.Name;
            var extension = Path.GetExtension(fileName);
            var file = new FileInfo(e.FullPath);
            switch (extension.ToLower())
            {
                case ".wav":
                case ".mp3":
                case ".m4a":
                    HandleAudioFile(file);
                    break;
                case ".mp4":
                case ".mkv":
                case ".mov":
                case ".avi":
                case ".wmv":
                case ".flv":
                case ".mpg":
                case ".mpeg":
                case ".m4v":
                case ".3gp":
                case ".3g2":
                case ".srt":
                    HandleVideoFile(file);
                    break;
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                case ".tiff":
                case ".tif":
                case ".svg":
                    HandleImageFile(file);
                    break;
                case ".pdf":
                case ".md":
                case ".doc":
                case ".docx":
                case ".xls":
                case ".xlsx":
                case ".ppt":
                case ".pptx":
                case ".txt":
                case ".rtf":    
                case ".epub":       
                case ".mobi":
                    HandleDocumentation(file);
                    break;
                case ".exe":
                case ".msi":
                case ".img":
                case ".iso":
                case ".dmg":
                case ".unitypackage":
                    HandleInstallers(file);
                    break;
                case ".zip":
                case ".rar":
                case ".7z":
                case ".tar":
                case ".gz":
                case ".bz2":
                    HandleBinaryFile(file);
                    break;
                case ".cs":
                case ".cshtml":
                case ".js":
                case ".css":
                case ".html":
                case ".htm":
                case ".ps1":
                case ".psm1":
                case ".py":
                case ".rb":
                case ".sh":
                case ".jsx":
                case ".ts":
                case ".tsx":
                case ".vb":
                case ".vbx":                  
                    HandleScripts(file);
                    break;
                case ".xml":
                case ".json":
                case ".csv":
                case ".tsv":
                    HandleData(file);
                    break;
                default:
                    HandleOther(file);
                    break;
            }


        }

        private void HandleOther(FileInfo file) => _logger.LogWarning("Unhandled File: {0}", file.Name);
        private void HandleData(FileInfo file) => MoveTo(file, "data");
        private void HandleInstallers(FileInfo file) => MoveTo(file, "installers");
        private void HandleBinaryFile(FileInfo file) => MoveTo(file, "binaries");
        private void HandleDocumentation(FileInfo file) => MoveTo(file, "documents");
        private void HandleImageFile(FileInfo file) => MoveTo(file, "pictures");
        private void HandleVideoFile(FileInfo file) => MoveTo(file, "videos");
        private void HandleScripts(FileInfo file) => MoveTo(file, "scripts");
        private void HandleAudioFile(FileInfo fileInfo)
        {
            var isSfx = fileInfo.Length < 25000000 || fileInfo.Name.Contains("sfx", StringComparison.OrdinalIgnoreCase);
            var destination = isSfx ? "sfx" : "music";
            MoveTo(fileInfo, destination);
        }

        private void MoveTo(FileInfo fileInfo, string destination)
        {
            var destinationPath = Path.Combine(fileInfo.Directory.FullName, destination, fileInfo.Name);
            _logger.LogInformation("Moving file {fileName} to {destination}", fileInfo.Name, destinationPath);
            Directory.CreateDirectory(Path.Combine(fileInfo.Directory.FullName, destination));
            fileInfo.MoveTo(destinationPath);
        }
    }
}