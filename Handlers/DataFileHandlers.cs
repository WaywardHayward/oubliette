namespace oubliette.Handlers;
internal class DataFileHandler : MoveFileHandler
{
    public DataFileHandler(ILogger<DataFileHandler> logger) : base(logger)
    {
    }

    public override HashSet<string> Extensions => new HashSet<string>
    { 
        ".xml",
        ".json",
        ".csv",
        ".tsv",
        ".dtdl",
        ".xsd",
        ".xsl",
        ".xslt",
        ".owl",
    };
    protected override string GetDestination(FileInfo file) => "data";
}