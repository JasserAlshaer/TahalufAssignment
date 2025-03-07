using Microsoft.EntityFrameworkCore;
using TahalufAssignmentCore.Context;
using TahalufAssignmentCore.DTOs.Auths;
using TahalufAssignmentCore.Entities.Authantication;
using TahalufAssignmentCore.Helpers;
using TahalufAssignmentCore.Services;

namespace TahalufAssignmentInfrastructure.Services
{
    public class AuthanticationService : IAuthanticationService
    {
        private readonly TahalufAssignmentDbContext _context;
        public AuthanticationService(TahalufAssignmentDbContext context)
        {
            _context = context;
        }
        public async Task<string> Login(LoginDTO input)
        {
            if (input != null)
            {
                if (!string.IsNullOrEmpty(input.Email) && !string.IsNullOrEmpty(input.Password))
                {
                    var hashed = HashingHelper.GenerateSHA384String(input.Email);
                    input.Password = HashingHelper.GenerateSHA384String(input.Password);
                    var authUser = await (from p in _context.Users
                                          where (p.Username == hashed || p.Email == input.Email) && p.Password == input.Password
                                          select p
                                          ).FirstOrDefaultAsync();
                    if(authUser != null)
                    {
                        authUser.IsLoggedIn = true;
                        authUser.LastLoginDate = DateTime.Now;
                        _context.Update(authUser);
                        _context.SaveChanges();
                        return authUser != null ? await TokenHelper.GenerateToken(authUser.Id.ToString(), "Admin") : "Authantication Failed";
                    }
                    else
                    {
                        throw new Exception("Invalid User Credintials");
                    }
                }
                else
                {
                    throw new Exception("Email and Password Are Required");
                }
            }
            else
            {

                throw new Exception("Email and Password Are Required");

            }
        }
        public async Task<bool> Logout(int Id)
        {
            if (Id != 0)
            {
                var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                if (User != null)
                {
                    User.IsLoggedIn = false;
                    _context.Update(User);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {

                throw new Exception("User Id  Required");

            }
        }
        public async Task<string> RegisterUser(SiteUserCreateDTO input)
        {
            if (input != null)
            {
                User User = new User()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email,
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsLoggedIn = false,
                    LastLoginDate = null,
                    ModifiedDate = null ,
                    UserType = input.UserType,
                    Password = HashingHelper.GenerateSHA384String(input.Password),
                    Username = HashingHelper.GenerateSHA384String(input.Username)
                };
                await _context.AddAsync(User);
                await _context.SaveChangesAsync();
                if (User.Id != 0)
                {
                    
                   
                    return ("Your Account Successfuly Completed");
                }
                else
                {
                    throw new Exception("Failed To Create Users");
                }
            }
            else
            {
                throw new Exception("All Information are Required");
            }
        }
    }
}
