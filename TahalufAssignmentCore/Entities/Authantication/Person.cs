using TahalufAssignmentCore.Entities.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.Entities.Authantication
{
    public class Person : ParentEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string? FirstNameAr { get; set; }
        public string? MiddleNameAr { get; set; }
        public string? LastNameAr { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public bool IsLoggedIn { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
