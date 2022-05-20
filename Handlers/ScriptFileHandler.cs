namespace oubliette.Handlers
{
    public class ScriptFileHandler : MoveFileHandler
    {
        public ScriptFileHandler(ILogger<ScriptFileHandler> logger) : base(logger)
        {
        }

        public override HashSet<string> Extensions => new HashSet<string> {
            ".cs",
            ".js",
            ".lua",
            ".py",
            ".rb",
            ".sh",
            ".pl",
            ".php",
            ".html",
            ".htm",
            ".css",
            ".xml",
            ".json",
            ".csv",
            ".tsv",
            ".dtdl",
            ".xsd",
            ".xsl",
            ".xslt",
            ".owl",
            ".yml",
            ".yaml",
            ".ini",
            ".cfg",
            ".bat",
            ".cmd",
            ".sh",
            ".ps1",
            ".psm1",
            ".psd1"
        };

        protected override string GetDestination(FileInfo file) => "scripts";
    }
}