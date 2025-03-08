using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.Entities.Management
{
    public class LookupItem : ParentEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int LookupTypeId { get; set; }
    }
}
