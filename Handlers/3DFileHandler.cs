namespace oubliette.Handlers
{
    public class FileHandler3D : MoveFileHandler
    {
        public FileHandler3D(ILogger<FileHandler3D> logger) : base(logger)
        {
        }

        public override HashSet<string> Extensions => new HashSet<string>{
            ".glb",
            ".stl",
            ".fbx",
            ".obj",
            ".blender",
            ".3ds",
            ".dae",
            ".dxf",
            ".x3d",
            ".x3db",
            ".x3dv",
            ".x3dz",
            ".x3dvz"
        };


        protected override string GetDestination(FileInfo file) => "3D";
    }
}