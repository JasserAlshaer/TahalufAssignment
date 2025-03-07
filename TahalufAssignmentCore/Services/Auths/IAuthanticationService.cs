using Microsoft.AspNetCore.Mvc;
using TahalufAssignmentCore.DTOs.Auths;

namespace TahalufAssignmentCore.Services
{
    public interface IAuthanticationService
    {
        Task<string> RegisterUser(SiteUserCreateDTO input);
        Task<string> VerifyOTP(VerificationInputDTO input);
        Task<string> Login(LoginDTO input);
        Task<bool> Logout(int Id);
    }
}
