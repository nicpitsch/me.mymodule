using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Me.MyModule.Models;

namespace Me.MyModule.Repository
{
    public class MyModuleRepository : IMyModuleRepository, IService
    {
        private readonly MyModuleContext _db;

        public MyModuleRepository(MyModuleContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.MyModule> GetMyModules(int ModuleId)
        {
            return _db.MyModule.Where(item => item.ModuleId == ModuleId);
        }

        public Models.MyModule GetMyModule(int MyModuleId)
        {
            return _db.MyModule.Find(MyModuleId);
        }

        public Models.MyModule AddMyModule(Models.MyModule MyModule)
        {
            _db.MyModule.Add(MyModule);
            _db.SaveChanges();
            return MyModule;
        }

        public Models.MyModule UpdateMyModule(Models.MyModule MyModule)
        {
            _db.Entry(MyModule).State = EntityState.Modified;
            _db.SaveChanges();
            return MyModule;
        }

        public void DeleteMyModule(int MyModuleId)
        {
            Models.MyModule MyModule = _db.MyModule.Find(MyModuleId);
            _db.MyModule.Remove(MyModule);
            _db.SaveChanges();
        }
    }
}
