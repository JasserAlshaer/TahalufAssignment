using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.APIs.Responses
{
    public class DatePaginationResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int ItemsCount { get; set; }
        public List<T> Items { get; set; }
    }
}
