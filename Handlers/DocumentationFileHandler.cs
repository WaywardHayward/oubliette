namespace oubliette.Handlers
{
    public class DocumentationFileHandler : MoveFileHandler
    {
        public DocumentationFileHandler(ILogger<DocumentationFileHandler> logger) : base(logger)
        {
        }

        public override HashSet<string> Extensions => new HashSet<string> {
            ".pdf",
            ".md",
            ".doc",
            ".docx",
            ".xls",
            ".xlsx",
            ".ppt",
            ".pptx",
            ".txt",
            ".rtf",
            ".epub",
            ".mobi"
        };

        protected override string GetDestination(FileInfo file) => "documentation";
    }
}