using System.Collections.Generic;
using Me.MyModule.Models;

namespace Me.MyModule.Repository
{
    public interface IMyModuleRepository
    {
        IEnumerable<Models.MyModule> GetMyModules(int ModuleId);
        Models.MyModule GetMyModule(int MyModuleId);
        Models.MyModule AddMyModule(Models.MyModule MyModule);
        Models.MyModule UpdateMyModule(Models.MyModule MyModule);
        void DeleteMyModule(int MyModuleId);
    }
}
