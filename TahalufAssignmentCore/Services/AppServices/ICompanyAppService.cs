using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahalufAssignmentCore.DTOs.APIs.Responses;
using TahalufAssignmentCore.DTOs.Companies;
using TahalufAssignmentCore.DTOs.Orgnizations;

namespace TahalufAssignmentCore.Services.AppServices
{
    public interface ICompanyAppService
    {
        Task CreateUpdateCompany(CreateUpdateCompanyDTO input);
        Task<LoadItemDTO<CompanyDTO>> SearchCompanies(SearchCompanyDTO input, int pageIndex, int pageSize);
        Task DeleteCompany(int Id);
        Task<CompanyInfoDTO> GetCompanyInfo(int Id);
    }
}
