namespace oubliette.Handlers
{
    public class AudioFileHandler : MoveFileHandler
    {
        public AudioFileHandler(ILogger<AudioFileHandler> logger) : base(logger)
        {
        }

        public override HashSet<string> Extensions => new HashSet<string> {
            ".wav",
            ".mp3",
            ".m4a"
        };
        
        protected override string GetDestination(FileInfo file)
        {
            var isSfx = file.Length < 25000000 || file.Name.Contains("sfx", StringComparison.OrdinalIgnoreCase);
            return isSfx ? "sfx" : "music";
        }
    }
}