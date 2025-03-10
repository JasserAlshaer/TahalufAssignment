using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahalufAssignmentCore.Context;
using TahalufAssignmentCore.DTOs.Dashboards;
using TahalufAssignmentCore.Services.AppServices;

namespace TahalufAssignmentInfrastructure.Services.AppServices
{
    public class DashboardAppService : IDashboardAppService
    {
        private readonly TahalufAssignmentDbContext _dbContext;

        public DashboardAppService(TahalufAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DashboardInfoDTO> GetInfoDTO()
        {
            DashboardInfoDTO infoDTO = new DashboardInfoDTO()
            {
                CompaniesCount = await _dbContext.Companies.CountAsync(),
                OrgnizationsCount = await _dbContext.Orgnizations.CountAsync(),
                UsersCount = await _dbContext.Users.CountAsync(),
            };
            return infoDTO;
        }
    }
}
