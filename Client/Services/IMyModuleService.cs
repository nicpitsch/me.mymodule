using System.Collections.Generic;
using System.Threading.Tasks;
using Me.MyModule.Models;

namespace Me.MyModule.Services
{
    public interface IMyModuleService 
    {
        Task<List<Models.MyModule>> GetMyModulesAsync(int ModuleId);

        Task<Models.MyModule> GetMyModuleAsync(int MyModuleId, int ModuleId);

        Task<Models.MyModule> AddMyModuleAsync(Models.MyModule MyModule);

        Task<Models.MyModule> UpdateMyModuleAsync(Models.MyModule MyModule);

        Task DeleteMyModuleAsync(int MyModuleId, int ModuleId);
    }
}
