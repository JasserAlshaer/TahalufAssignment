using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.Companies
{
    public class CompanyDTO
    {
        public int Id { get; set; } 
        public string CountryName { get; set; }
        public string OrgnizationName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CreationDate { get; set; }
    }
}
