using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Me.MyModule.Models
{
    [Table("MeMyModule")]
    public class MyModule : IAuditable
    {
        public int MyModuleId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
