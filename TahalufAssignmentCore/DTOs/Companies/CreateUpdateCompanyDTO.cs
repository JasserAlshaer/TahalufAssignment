using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.Companies
{
    public class CreateUpdateCompanyDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int OrganizationId { get; set; }
    }
}
