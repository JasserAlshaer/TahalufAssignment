using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahalufAssignmentCore.DTOs.Dashboards;

namespace TahalufAssignmentCore.Services.AppServices
{
    public interface IDashboardAppService
    {
        Task<DashboardInfoDTO> GetInfoDTO();
    }
}
