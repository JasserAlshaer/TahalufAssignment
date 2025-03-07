using Microsoft.AspNetCore.Mvc;
using TahalufAssignmentCore.Attributes;
using TahalufAssignmentCore.DTOs.APIs.Requests;
using TahalufAssignmentCore.DTOs.APIs.Responses;
using TahalufAssignmentCore.DTOs.LookupItem;
using TahalufAssignmentCore.Services;
using Serilog;

namespace TahalufAssignmentAPI.Controllers.Lookups
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupItemController : ControllerBase
    {
        private readonly ILookupItemServices _lookupItemServices;
        public LookupItemController(ILookupItemServices lookupItemServices)
        {
            _lookupItemServices = lookupItemServices;
        }


        [HttpGet("GetLookupItem")]
        [RoleRequirement("Admin")]
        public async Task<IActionResult> GetLookupItem([FromQuery]DatePaginationRequest<LookupItemFillterationDto> input)
        {
            var response = new DatePaginationResponse<LookupItemDto>();
            Log.Information("Get LookupItems Start Execution");
            try
            {
                var items = await _lookupItemServices.GetLookupItem();
                response.Items = items;
                response.StatusCode = items.Count > 0 ? 200 : 204;
                response.Message = $"Completed Done";
                Log.Information($"Completed Done Return {response.Items} LookupItems");
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Get All LookupItems");
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


        [HttpPost("CreateLookupItem")]
        [RoleRequirement("Admin")]
        public async Task<IActionResult> CreateLookupItem(CreateLookupItemDto input)
        {
            var response = new DataResponseDto<bool>();
            Log.Information("CreateLookupItem Start Execution");
            try
            {
                var result = await _lookupItemServices.CreateLookupItem(input);
                response.Entity = true;
                response.StatusCode = 200;
                response.Message = $"Completed CreateLookupItem {input.Name}";
                Log.Information(response.Message);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Log.Error("Failed To CreateLookupItem");
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

        [HttpPut("ManageLookupItemActivation")]
        [RoleRequirement("Admin")]
        public async Task<IActionResult> ManageLookupItemActivation(LookupItemActivationDto input)
        {
            var response = new DataResponseDto<bool>();
            Log.Information("ManageClientActivation Start Execution");
            try
            {
                var result = await _lookupItemServices.ManageLookupItemActivation(input);
                response.Entity = true;
                response.StatusCode = 200;
                response.Message = $"Completed ManageClientActivation {input.Id}";
                Log.Information(response.Message);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                Log.Error("Failed To ManageClientActivation");
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
