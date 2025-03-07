using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TahalufAssignmentCore.Attributes;
using TahalufAssignmentCore.DTOs.APIs.Requests;
using TahalufAssignmentCore.DTOs.APIs.Responses;
using TahalufAssignmentCore.DTOs.Companies;
using TahalufAssignmentCore.DTOs.Orgnizations;
using TahalufAssignmentCore.Services.AppServices;

namespace TahalufAssignmentAPI.Controllers.Orgnizations
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationAppService _organizationAppService;
        public OrganizationController(IOrganizationAppService organizationAppService) {
            _organizationAppService = organizationAppService;
        }
        [RoleRequirement("Admin")]
        [HttpGet("Get-Orgnization/{Id}")]
        public async Task<IActionResult> GetOrgnization([FromRoute] int Id)
        {
            try
            {
                var item = await _organizationAppService.GetOrgnizationInfo(Id);
                var response = new DataResponseDto<OrgnizationInfoDTO>()
                {
                    Entity = item,
                    Message = "Orgnization Has been Removed From The System",
                    StatusCode = 200
                };
                return StatusCode(200, response);

            }
            catch (Exception ex)
            {
                var error = new ErrorResponseDto()
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Details = ex.StackTrace,
                    Timestamp = DateTime.Now
                };
                Log.Error("Error Was Occured on Get Orgnization Information");
                return StatusCode(500, error);
            }
        }
        [RoleRequirement("Admin")]
        [HttpGet("Search-Orgnization")]
        public async Task<IActionResult> GetSearchOrgnization([FromQuery] DatePaginationRequest<SearchOrgnizationDTO> input)
        {
            try
            {
                var item = await _organizationAppService.SearchOrgnization(input.Input??new SearchOrgnizationDTO(),input.Index,input.Size);
                var response = new DatePaginationResponse<OrgnizationDTO>()
                {
                    Items = item.Items,
                    ItemsCount = item.TotalItem,
                    Message = "Orgnization Has been Removed From The System",
                    StatusCode = 200
                };
                return StatusCode(200, response);

            }
            catch (Exception ex)
            {
                var error = new ErrorResponseDto()
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Details = ex.StackTrace,
                    Timestamp = DateTime.Now
                };
                Log.Error("Error Was Occured on Get Orgnization Information");
                return StatusCode(500, error);
            }
        }
        [RoleRequirement("Admin")]
        [HttpPost("Create-Orgnization")]
        [HttpPut("Update-Orgnization")]
        public async Task<IActionResult> CreateUpdateOrgnization([FromBody] CreateUpdateOrganizationDTO input)
        {
            try
            {
                await _organizationAppService.CreateUpdateOrgnization(input);
                var response =  new DataResponseDto<string>()
                {
                    Entity = "Orgnization",
                    Message = input.Id == null ?"New Orgnization Has been Created":"Orgnization Has been Updated",
                    StatusCode = 200
                };
                return StatusCode(200, response);

            }
            catch (Exception ex)
            {
                var error =  new ErrorResponseDto()
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Details = ex.StackTrace,
                    Timestamp = DateTime.Now
                };
                Log.Error("Error Was Occured on Create Update Orgnization");
                return StatusCode(500, error);
            }
        }
        [RoleRequirement("Admin")]
        [HttpDelete("Delete-Orgnization/{Id}")]
        public async Task<IActionResult> DeleteOrgnization([FromRoute] int Id)
        {
            try
            {
                await _organizationAppService.DeleteOrgnization(Id);
                var response = new DataResponseDto<string>()
                {
                    Entity = "Orgnization",
                    Message =  "Orgnization Has been Removed From The System",
                    StatusCode = 200
                };
                return StatusCode(200, response);

            }
            catch (Exception ex)
            {
                var error = new ErrorResponseDto()
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Details = ex.StackTrace,
                    Timestamp = DateTime.Now
                };
                Log.Error("Error Was Occured on Delete Orgnization");
                return StatusCode(500, error);
            }
        }
    }
}
