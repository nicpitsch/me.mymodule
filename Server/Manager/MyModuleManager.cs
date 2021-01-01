using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Me.MyModule.Models;
using Me.MyModule.Repository;

namespace Me.MyModule.Manager
{
    public class MyModuleManager : IInstallable, IPortable
    {
        private IMyModuleRepository _MyModuleRepository;
        private ISqlRepository _sql;

        public MyModuleManager(IMyModuleRepository MyModuleRepository, ISqlRepository sql)
        {
            _MyModuleRepository = MyModuleRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Me.MyModule." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Me.MyModule.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.MyModule> MyModules = _MyModuleRepository.GetMyModules(module.ModuleId).ToList();
            if (MyModules != null)
            {
                content = JsonSerializer.Serialize(MyModules);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.MyModule> MyModules = null;
            if (!string.IsNullOrEmpty(content))
            {
                MyModules = JsonSerializer.Deserialize<List<Models.MyModule>>(content);
            }
            if (MyModules != null)
            {
                foreach(var MyModule in MyModules)
                {
                    _MyModuleRepository.AddMyModule(new Models.MyModule { ModuleId = module.ModuleId, Name = MyModule.Name });
                }
            }
        }
    }
}