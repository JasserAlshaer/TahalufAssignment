using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahalufAssignmentCore.Attributes;
using TahalufAssignmentCore.Services.AppServices;

namespace TahalufAssignmentAPI.Controllers.Dashboards
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardAppService _dashboardAppService; 
        public DashboardController(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }
        [HttpGet("[action]")]
        [RoleRequirement("Admin")]
        public async Task<IActionResult> GetDashbaordStastics()
        {
            try
            {
                var response = await _dashboardAppService.GetInfoDTO();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
