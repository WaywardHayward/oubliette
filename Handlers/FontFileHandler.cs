namespace oubliette.Handlers
{
    public class FontFileHandler : MoveFileHandler
    {
        public FontFileHandler(ILogger<FontFileHandler> logger) : base(logger)
        {
        }

        public override HashSet<string> Extensions => new HashSet<string> {
            ".ttf",
            ".otf",
            ".woff",
            ".woff2",
            ".eot",
            ".svg",
            ".svgz",
            ".ttc",
            ".dfont",
            ".pfb",
            ".pfm",
            ".pfa",
            ".pcf",
            ".pcf.gz",
            ".pcf.z",
            ".pcf.bz2",
            ".pcf.xz",
            ".pcf.lzma",
            ".pcf.lzo",
            ".pcf.lz",
            ".pcf.gz",
            ".pcf.z",
            ".pcf.bz2",
            ".pcf.xz",
            ".pcf.lzma",
            ".pcf.lzo",
            ".pcf.lz",
            ".pcf.gz",
            ".pcf.z",
            ".pcf.bz2",
            ".pcf.xz",
            ".pcf.lzma",
            ".pcf.lzo",
            ".pcf.lz",
            ".pcf.gz",
            ".pcf.z",
            ".pcf.bz2",
            ".pcf.xz",
            ".pcf.lzma",
            ".pcf.lzo",
            ".pcf.lz",
            ".pcf.gz",
            ".pcf.z",
            ".pcf.bz2",
            ".pcf.xz",
            ".pcf.lzma",
            ".pcf.lzo",
            ".pcf.lz",
            ".pcf.gz",
            ".pcf.z",
            ".pcf.bz2",
            ".pcf.xz",
            ".pcf.lzma",
            ".pcf.lzo",
            ".pcf.lz",
            ".pcf.gz",
            ".pcf.z",
            ".pcf.bz2",
            ".pcf.xz"
        };

        protected override string GetDestination(FileInfo file) => "fonts";
    }
}