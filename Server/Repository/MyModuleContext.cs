using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Me.MyModule.Models;

namespace Me.MyModule.Repository
{
    public class MyModuleContext : DBContextBase, IService
    {
        public virtual DbSet<Models.MyModule> MyModule { get; set; }

        public MyModuleContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
