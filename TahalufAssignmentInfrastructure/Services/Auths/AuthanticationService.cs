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
                        var code = new Random().Next(111111, 999999);
                        VerificationCode verfication = new VerificationCode()
                        {
                            Code = code.ToString(),
                            CreationDate = DateTime.Now,
                            Email = authUser.Email,
                            IsActive = true,
                            ModifiedDate = null
                        };
                        await _context.AddAsync(verfication);
                        await _context.SaveChangesAsync();
                        return authUser != null ? await EmailService.SendEmailUsingMailKetService("Verification Code", authUser.Email, code.ToString(), "Your Login Successfuly Completed") : "Authantication Failed";
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
                var person = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                if (person != null)
                {
                    person.IsLoggedIn = false;
                    _context.Update(person);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {

                throw new Exception("Person Id  Required");

            }
        }
        public async Task<string> RegisterUser(SiteUserCreateDTO input)
        {
            if (input != null)
            {
                Person person = new Person()
                {
                    FirstName = input.FirstName,
                    MiddleName = input.MiddleName,
                    LastName = input.LastName,
                    Email = input.Email,
                    FirstNameAr = input.FirstNameAr,
                    MiddleNameAr = input.MiddleNameAr,
                    LastNameAr = input.LastNameAr,  
                    CreatedBy = "Jasser Alshaer",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    IsEmailConfirmed = false,
                    IsLoggedIn = false,
                    IsPhoneConfirmed = false,
                    LastLoginDate = null,
                    ModifiedDate = null ,
                    UserType = input.UserType,
                    Password = HashingHelper.GenerateSHA384String(input.Password),
                    Phone = input.Phone,
                    Username = HashingHelper.GenerateSHA384String(input.Username),
                    UpdatedBy = null
                };
                await _context.AddAsync(person);
                await _context.SaveChangesAsync();
                if (person.Id != 0)
                {
                    var code = new Random().Next(111111, 999999);
                    VerificationCode verfication = new VerificationCode()
                    {
                        Code = code.ToString(),
                        CreationDate = DateTime.Now,
                        Email = input.Email,
                        IsActive = true,
                        ModifiedDate = null
                    };
                    await _context.AddAsync(verfication);
                    await _context.SaveChangesAsync();
                    return person != null ? await EmailService.SendEmailUsingMailKetService("Verification Code", input.Email, code.ToString(), "Your Account Successfuly Completed") : "Failed Create New Account";
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
        public async Task<string> VerifyOTPForCreateAccount(VerificationInputDTO input)
        {
            if (input != null)
            {
                var code = await _context.VerificationCodes.FirstOrDefaultAsync(x => x.Email == input.Email
                && x.Code == input.Code);
                if (code != null)
                {
                    code.IsActive = false;
                    code.ModifiedDate = DateTime.Now;
                    _context.Update(code);
                    _context.SaveChanges();

                    var person = await _context.Users.FirstOrDefaultAsync(x => x.Email == input.Email);
                    if (person != null)
                    {
                        person.IsEmailConfirmed = true;
                        person.IsActive = true;
                        return "Email Confirmed Successfully";
                    }
                    else
                    {
                        throw new Exception("No Any User To Verify");
                    }
                    
                }
                throw new Exception("Failed Verifiy OTP");
            }
            else
            {
                throw new Exception("Email and Password Are Required");
            }
        }
        public async Task<string> VerifyOTP(VerificationInputDTO input)
        {
            if (input != null)
            {
                var code = await _context.VerificationCodes.FirstOrDefaultAsync(x => x.Email == input.Email
                && x.Code == input.Code);
                if (code != null)
                {
                    code.IsActive = false;
                    code.ModifiedDate = DateTime.Now;
                    _context.Update(code);
                    _context.SaveChanges();

                    var person = await _context.Users.FirstOrDefaultAsync(x => x.Email == input.Email);
                    return person != null ? await TokenHelper.GenerateToken(person.Id.ToString(), "Admin") : "Authantication Failed";
                }
                throw new Exception("Failed Verifiy OTP");
            }
            else
            {
                throw new Exception("Email and Password Are Required");
            }
        }
    }
}
