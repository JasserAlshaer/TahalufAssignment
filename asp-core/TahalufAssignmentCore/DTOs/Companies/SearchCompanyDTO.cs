using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.Companies
{
    public class SearchCompanyDTO
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? OrgnizationId { get; set; }
        public int?   CountryId { get; set; }
    }
}
