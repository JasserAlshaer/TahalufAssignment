using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahalufAssignmentCore.Entities.Management;

namespace TahalufAssignmentCore.Entities.Companies
{
    public class Company : ParentEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int OrgnizationId { get; set; }
    }
}
