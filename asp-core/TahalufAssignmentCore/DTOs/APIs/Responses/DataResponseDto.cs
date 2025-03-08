using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.APIs.Responses
{
    public class DataResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Entity { get; set; }
    }
}
