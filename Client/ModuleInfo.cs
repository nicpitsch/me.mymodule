using Oqtane.Models;
using Oqtane.Modules;

namespace Me.MyModule
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "MyModule",
            Description = "MyModule",
            Version = "1.0.0",
            ServerManagerType = "Me.MyModule.Manager.MyModuleManager, Me.MyModule.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Me.MyModule.Shared.Oqtane"
        };
    }
}
