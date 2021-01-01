using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Me.MyModule.Models;

namespace Me.MyModule.Services
{
    public class MyModuleService : ServiceBase, IMyModuleService, IService
    {
        private readonly SiteState _siteState;

        public MyModuleService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "MyModule");

        public async Task<List<Models.MyModule>> GetMyModulesAsync(int ModuleId)
        {
            List<Models.MyModule> MyModules = await GetJsonAsync<List<Models.MyModule>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return MyModules.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.MyModule> GetMyModuleAsync(int MyModuleId, int ModuleId)
        {
            return await GetJsonAsync<Models.MyModule>(CreateAuthorizationPolicyUrl($"{Apiurl}/{MyModuleId}", ModuleId));
        }

        public async Task<Models.MyModule> AddMyModuleAsync(Models.MyModule MyModule)
        {
            return await PostJsonAsync<Models.MyModule>(CreateAuthorizationPolicyUrl($"{Apiurl}", MyModule.ModuleId), MyModule);
        }

        public async Task<Models.MyModule> UpdateMyModuleAsync(Models.MyModule MyModule)
        {
            return await PutJsonAsync<Models.MyModule>(CreateAuthorizationPolicyUrl($"{Apiurl}/{MyModule.MyModuleId}", MyModule.ModuleId), MyModule);
        }

        public async Task DeleteMyModuleAsync(int MyModuleId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{MyModuleId}", ModuleId));
        }
    }
}
