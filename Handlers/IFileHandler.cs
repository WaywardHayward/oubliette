namespace oubliette.Handlers
{
    public interface IFileHandler
    {
        void HandleFile(object sender, FileSystemEventArgs e);
    }
}