using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.APIs.Requests
{
    public class DatePaginationRequest<T>
    {
        public int? Size { get; set; }
        public int? Index { get; set; }
        public T? Input { get; set; }
    }
}
