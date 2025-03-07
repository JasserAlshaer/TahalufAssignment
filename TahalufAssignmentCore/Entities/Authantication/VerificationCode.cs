using TahalufAssignmentCore.Entities.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.Entities.Authantication
{
    public class VerificationCode : ParentEntity
    {
        public string Code { get; set; }
        public string Email { get; set; }
        public int IsUsed { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
