using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.APIs.Requests
{
    public class DatePaginationRequest<T>
    {
        public int Size { get; set; } = 10;
        public int Index { get; set; } = 0;
        public T? Input { get; set; }
    }
}
