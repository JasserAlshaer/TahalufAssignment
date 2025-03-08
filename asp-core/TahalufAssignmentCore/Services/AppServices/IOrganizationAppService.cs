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
    public interface IOrganizationAppService
    {
        Task CreateUpdateOrgnization(CreateUpdateOrganizationDTO input);
        Task<LoadItemDTO<OrgnizationDTO>> SearchOrgnization(SearchOrgnizationDTO input, int pageIndex, int pageSize);
        Task DeleteOrgnization(int Id); 
        Task<OrgnizationInfoDTO> GetOrgnizationInfo(int Id);
    }
}
