using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.Companies
{
    public class CompanyInfoDTO
    {
        public int    Id { get; set; }
        public int OrganizationId { get; set;}
        public string OrgnizationName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int    CountryId { get; set; }
        public string Country { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}
