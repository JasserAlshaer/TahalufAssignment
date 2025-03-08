using Microsoft.AspNetCore.Mvc;
using TahalufAssignmentCore.Attributes;
using TahalufAssignmentCore.DTOs.APIs.Responses;
using TahalufAssignmentCore.DTOs.Lookups;
using TahalufAssignmentCore.Services;
using Serilog;

namespace TahalufAssignmentAPI.Controllers.Lookups
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupTypeController : ControllerBase
    {
        private readonly ILookupTypeServices _lookupTypeServices;

        public LookupTypeController(ILookupTypeServices lookupTypeServices)
        {
            _lookupTypeServices = lookupTypeServices;
        }

        [HttpGet("GetLookupType")]
        [RoleRequirement("Admin")]
        public async Task<IActionResult> GetLookupType()
        {
            var response = new DatePaginationResponse<LookupTypeDto>();
            Log.Information("Get LookupTypes Start Execution");
            try
            {
                var items = await _lookupTypeServices.GetLookupType();
                response.Items = items;
                response.StatusCode = items.Count > 0 ? 200 : 204;
                response.Message = $"Completed Done";
                Log.Information($"Completed Done Return {response.Items} LookupTypes");
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Get All LookupTypes");
                Log.Error(ex.Message);
                Log.Error(ex.StackTrace);
                return StatusCode(500, new ErrorResponseDto
                {
                    StatusCode = 500,
                    Details = ex.StackTrace,
                    Message = ex.Message,
                    Timestamp = DateTime.Now
                });
            }
        }


    }
}
