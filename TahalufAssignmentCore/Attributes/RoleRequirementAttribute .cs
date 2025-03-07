using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RoleRequirementAttribute : Attribute
    {
        public string Role { get; }

        public RoleRequirementAttribute(string role)
        {
            Role = role;
        }
    }
}
