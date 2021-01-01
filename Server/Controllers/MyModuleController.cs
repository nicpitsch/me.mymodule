using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Me.MyModule.Models;
using Me.MyModule.Repository;

namespace Me.MyModule.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class MyModuleController : Controller
    {
        private readonly IMyModuleRepository _MyModuleRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public MyModuleController(IMyModuleRepository MyModuleRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _MyModuleRepository = MyModuleRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.MyModule> Get(string moduleid)
        {
            return _MyModuleRepository.GetMyModules(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.MyModule Get(int id)
        {
            Models.MyModule MyModule = _MyModuleRepository.GetMyModule(id);
            if (MyModule != null && MyModule.ModuleId != _entityId)
            {
                MyModule = null;
            }
            return MyModule;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.MyModule Post([FromBody] Models.MyModule MyModule)
        {
            if (ModelState.IsValid && MyModule.ModuleId == _entityId)
            {
                MyModule = _MyModuleRepository.AddMyModule(MyModule);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "MyModule Added {MyModule}", MyModule);
            }
            return MyModule;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.MyModule Put(int id, [FromBody] Models.MyModule MyModule)
        {
            if (ModelState.IsValid && MyModule.ModuleId == _entityId)
            {
                MyModule = _MyModuleRepository.UpdateMyModule(MyModule);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "MyModule Updated {MyModule}", MyModule);
            }
            return MyModule;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.MyModule MyModule = _MyModuleRepository.GetMyModule(id);
            if (MyModule != null && MyModule.ModuleId == _entityId)
            {
                _MyModuleRepository.DeleteMyModule(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "MyModule Deleted {MyModuleId}", id);
            }
        }
    }
}
