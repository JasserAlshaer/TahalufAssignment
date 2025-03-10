using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TahalufAssignmentCore.Attributes;
using TahalufAssignmentCore.DTOs.APIs.Requests;
using TahalufAssignmentCore.DTOs.APIs.Responses;
using TahalufAssignmentCore.DTOs.Companies;
using TahalufAssignmentCore.Services.AppServices;

namespace TahalufAssignmentAPI.Controllers.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyAppService _companyAppService;
        public CompaniesController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }
        [RoleRequirement("Admin")]
        [HttpGet("Get-Company/{Id}")]
        public async Task<IActionResult> GetCompany([FromRoute] int Id)
        {
            try
            {
                var item = await _companyAppService.GetCompanyInfo(Id);
                var response = new DataResponseDto<CompanyInfoDTO>()
                {
                    Entity = item,
                    Message = "Company Has been Removed From The System",
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
                Log.Error("Error Was Occured on Get Company Information");
                return StatusCode(500, error);
            }
        }
        [RoleRequirement("Admin")]
        [HttpGet("Search-Company")]
        public async Task<IActionResult> GetSearchCompany([FromQuery] SearchCompanyDTO  input, [FromQuery] DatePaginationRequest<object> request)
        {
            try
            {
                var item = await _companyAppService.SearchCompanies(input ?? new SearchCompanyDTO(), request.Index, request.Size);
                var response = new DatePaginationResponse<CompanyDTO>()
                {
                    Items = item.Items,
                    ItemsCount = item.TotalItem,
                    Message = "Company Has been Retreived From The System",
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
                Log.Error("Error Was Occured on Get Company Information");
                return StatusCode(500, error);
            }
        }
        [RoleRequirement("Admin")]
        [HttpPost("Create-Company")]
        [HttpPut("Update-Company")]
        public async Task<IActionResult> CreateUpdateCompany([FromBody] CreateUpdateCompanyDTO input)
        {
            try
            {
                await _companyAppService.CreateUpdateCompany(input);
                var response = new DataResponseDto<string>()
                {
                    Entity = "Company",
                    Message = input.Id == null ? "New Company Has been Created" : "Company Has been Updated",
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
                Log.Error("Error Was Occured on Create Update Company");
                return StatusCode(500, error);
            }
        }
        [RoleRequirement("Admin")]
        [HttpDelete("Delete-Company/{Id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int Id)
        {
            try
            {
                await _companyAppService.DeleteCompany(Id);
                var response = new DataResponseDto<string>()
                {
                    Entity = "Company",
                    Message = "Company Has been Removed From The System",
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
                Log.Error("Error Was Occured on Delete Company");
                return StatusCode(500, error);
            }
        }
    }
}
