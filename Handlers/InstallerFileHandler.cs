namespace oubliette.Handlers
{
    public class InstallerFileHandler : MoveFileHandler
    {
        public InstallerFileHandler(ILogger<InstallerFileHandler> logger) : base(logger)
        {
        }

        public override HashSet<string> Extensions => new HashSet<string> {
                 ".exe",
                 ".msi",
                 ".img",
                 ".iso",
                 ".dmg",
                 ".unitypackage"
        };

        protected override string GetDestination(FileInfo file) => "installers";
    }
}