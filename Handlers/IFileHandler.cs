namespace oubliette.Handlers
{
    public interface IFileHandler
    {
        HashSet<string> Extensions { get; }
        void HandleFile(object sender, FileSystemEventArgs e);
    }
}